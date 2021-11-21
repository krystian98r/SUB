using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Coupons
{
    public class CreateModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public CreateModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["WydarzenieId"] = new SelectList(_context.Wydarzenie, "Id", "Gosc");
            return Page();
        }

        [BindProperty]
        public Kupon Kupon { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kupon.Add(Kupon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
