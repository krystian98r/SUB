using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Temp
{
    public class DeleteModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public DeleteModel(SUB.Data.SUBContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Portfel = await _context.Portfel.FindAsync(id);

            if (Portfel != null)
            {
                _context.Portfel.Remove(Portfel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
