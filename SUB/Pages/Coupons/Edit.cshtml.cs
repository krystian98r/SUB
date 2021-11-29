using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Coupons
{
    public class EditModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Kupon Kupon { get; set; }
        public HistoriaPortfela HistoriaPortfela { get; set; }
        [BindProperty]
        public AspNetUsers Uzytkownik { get; set; }
        public Portfel Portfel { get; set; }
        [BindProperty]
        public double SrodkiPrzed { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });
            if (id == null)
            {
                return NotFound();
            }

            Kupon = await _context.Kupon
                .Include(k => k.Wydarzenie).FirstOrDefaultAsync(m => m.Id == id);

            if (Kupon.Wydarzenie.Data < DateTime.Now || (!Kupon.UzytkownikId.Equals(_userManager.GetUserId(User)) && !User.IsInRole("BookmakerObserver"))) return RedirectToPage("/Index");

            if (Kupon == null)
            {
                SrodkiPrzed = 0;
                return NotFound();
            }
            else
            {
                SrodkiPrzed = Kupon.Srodki;
            }

            ViewData["UzytkownikId"] = new SelectList(_context.Set<AspNetUsers>(), "Id", "Id");
            ViewData["WydarzenieId"] = new SelectList(_context.Wydarzenie, "Id", "SkrotWydarzenia");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            if (SrodkiPrzed != Kupon.Srodki)
            {
                var roznica = SrodkiPrzed - Kupon.Srodki;

                Uzytkownik = await _context.AspNetUsers.Include(k => k.Portfel).FirstOrDefaultAsync(x => x.Id.Equals(Kupon.UzytkownikId));
                Uzytkownik.Portfel.Srodki += roznica;
                HistoriaPortfela = new HistoriaPortfela((int)Uzytkownik.PortfelId, roznica, Uzytkownik.Portfel.Srodki, "Edycja kuponu");
                _context.HistoriaPortfela.Add(HistoriaPortfela);
            }
            _context.Attach(Kupon).State = EntityState.Modified;
            await _context.SaveChangesAsync();


            return RedirectToPage("./List");
        }

        private bool KuponExists(int id)
        {
            return _context.Kupon.Any(e => e.Id == id);
        }
    }
}
