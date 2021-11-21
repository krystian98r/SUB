using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Contact
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
        ViewData["UzytkownikId"] = new SelectList(_context.Set<AspNetUsers>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Zgloszenie Zgloszenie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Zgloszenie.Status = "Przyjęto";

            _context.Zgloszenie.Add(Zgloszenie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
