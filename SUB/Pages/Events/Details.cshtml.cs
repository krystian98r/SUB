using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Areas.Events.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public DetailsModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        public Wydarzenie Wydarzenie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wydarzenie = await _context.Wydarzenie.FirstOrDefaultAsync(m => m.Id == id);

            if (Wydarzenie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
