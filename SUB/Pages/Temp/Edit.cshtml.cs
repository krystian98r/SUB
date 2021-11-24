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

namespace SUB.Pages.Temp
{
    public class EditModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public EditModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Portfel Portfel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Portfel = await _context.Portfel.FirstOrDefaultAsync(m => m.Id == id);

            if (Portfel == null)
            {
                return NotFound();
            }
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

            _context.Attach(Portfel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfelExists(Portfel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PortfelExists(int id)
        {
            return _context.Portfel.Any(e => e.Id == id);
        }
    }
}
