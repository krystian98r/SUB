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

namespace SUB.Pages.Contact
{
    public class EditModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public EditModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Zgloszenie Zgloszenie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zgloszenie = await _context.Zgloszenie
                .Include(z => z.Uzytkownik).FirstOrDefaultAsync(m => m.Id == id);

            if (Zgloszenie == null)
            {
                return NotFound();
            }
           ViewData["UzytkownikId"] = new SelectList(_context.Set<AspNetUsers>(), "Id", "Id");
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

            _context.Attach(Zgloszenie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZgloszenieExists(Zgloszenie.Id))
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

        private bool ZgloszenieExists(int id)
        {
            return _context.Zgloszenie.Any(e => e.Id == id);
        }
    }
}
