using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Coupons
{
    public class DetailsModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public DetailsModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        public Kupon Kupon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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
            return Page();
        }
    }
}
