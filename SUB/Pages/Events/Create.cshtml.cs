using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUB.Data;
using SUB.Models;

namespace SUB.Areas.Events.Pages
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
            if(!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });
            if (!User.IsInRole("BookmakerObserver")) return RedirectToPage("/Permissions");
            return Page();
        }

        [BindProperty]
        public Wydarzenie Wydarzenie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Wydarzenie.Add(Wydarzenie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
