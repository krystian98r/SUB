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

namespace SUB.Pages.Coupons
{
    public class EditModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public EditModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kupon Kupon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });
            if (id == null)
            {
                return NotFound();
            }

            Kupon = await _context.Kupon
                .Include(k => k.Wydarzenie).FirstOrDefaultAsync(m => m.Id == id);

            if (Kupon == null)
            {
                return NotFound();
            }
            ViewData["UzytkownikId"] = new SelectList(_context.Set<AspNetUsers>(), "Id", "Id");
            ViewData["WydarzenieId"] = new SelectList(_context.Wydarzenie, "Id", "SkrotWydarzenia");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Kupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KuponExists(Kupon.Id))
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

        private bool KuponExists(int id)
        {
            return _context.Kupon.Any(e => e.Id == id);
        }
    }
}
