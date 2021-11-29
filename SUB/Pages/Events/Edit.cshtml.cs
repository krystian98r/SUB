using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Areas.Events.Pages
{
    public class EditModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public EditModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wydarzenie Wydarzenie { get; set; }
        public List<Kupon> wygraneKupony { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });
            if (!User.IsInRole("BookmakerObserver")) return RedirectToPage("/Permissions");
            if (id == null)
            {
                return NotFound();
            }

            Wydarzenie = await _context.Wydarzenie.FirstOrDefaultAsync(m => m.Id == id);

            if (Wydarzenie == null)
            {
                return NotFound();
            }

            if (Wydarzenie.WynikWydarzenia != null) return RedirectToPage("/Index");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wydarzenie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                if(Wydarzenie.WynikWydarzenia != null) {
                    var wynik = Wydarzenie.WynikWydarzenia;
                    var id = Wydarzenie.Id;
                    wygraneKupony = await _context.Kupon.Include(k => k.Uzytkownik).Include(k => k.Wydarzenie).Where(x => x.ObstawionyKurs == wynik && x.WydarzenieId == id).ToListAsync();
                    wygraneKupony.ForEach(a =>
                    {
                        AspNetUsers uzytkownik = _context.AspNetUsers.Include(k => k.Portfel).Where(x => x.Id.Equals(a.UzytkownikId)).FirstOrDefault();
                        uzytkownik.Portfel.Srodki += a.PotencjalnaWygrana;
                        HistoriaPortfela historiaPortfela = new HistoriaPortfela((int)a.Uzytkownik.PortfelId, a.PotencjalnaWygrana, a.Uzytkownik.Portfel.Srodki, "Wygrana");
                        _context.HistoriaPortfela.Add(historiaPortfela);
                        _context.SaveChanges();
                    });
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WydarzenieExists(Wydarzenie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./List");
        }

        private bool WydarzenieExists(int id)
        {
            return _context.Wydarzenie.Any(e => e.Id == id);
        }
    }
}
