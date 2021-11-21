using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Contact
{
    public class DetailsModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public DetailsModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
