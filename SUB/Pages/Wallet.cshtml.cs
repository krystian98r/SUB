using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUB.Models;
using SUB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SUB.Pages
{
    /// <summary>
    /// Klasa reprezentująca podstronę "Portfel" oraz jej funckje
    /// </summary>
    public class WalletModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IList<AspNetUsers> AspNetUsers { get; set; }

        [BindProperty]
        public Portfel Portfel { get; set; }

        public WalletModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Portfel.Add(Portfel);
            await _context.SaveChangesAsync();

            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);
            var uzytkownik = _context.AspNetUsers.SingleOrDefault(x => x.Id.Equals(userId));
            uzytkownik.PortfelId = Portfel.Id;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task OnGetAsync()
        { 
            AspNetUsers = await _context.AspNetUsers
                .Include(z => z.Portfel).ToListAsync();
        }
    }
}
