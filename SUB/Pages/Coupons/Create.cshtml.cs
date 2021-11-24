using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Coupons
{
    public class CreateModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public AspNetUsers Uzytkownik { get; set; }
        [BindProperty]
        public Portfel Portfel { get; set; }

        public CreateModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });
            ViewData["UzytkownikId"] = new SelectList(_context.Set<AspNetUsers>(), "Id", "UserName");
            ViewData["WydarzenieId"] = new SelectList(_context.Wydarzenie, "Id", "SkrotWydarzenia");

            return Page();
        }

        [BindProperty]
        public Kupon Kupon { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);

            Uzytkownik = _context.AspNetUsers.SingleOrDefault(x => x.Id.Equals(userId));
            Portfel = await _context.Portfel.FirstOrDefaultAsync(x => x.Id == Uzytkownik.PortfelId);

            if (Portfel.Srodki < Kupon.Srodki) return Page();
            else
            {
                _context.Kupon.Add(Kupon);
                Uzytkownik.Portfel.Srodki -= Kupon.Srodki;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./List");
        }
    }
}
