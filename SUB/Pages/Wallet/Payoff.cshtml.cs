using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SUB.Pages.Wallet
{
    public class PayoffModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IList<AspNetUsers> AspNetUsers { get; set; }

        [BindProperty]
        public Portfel Portfel { get; set; }

        public PayoffModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
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

            return RedirectToPage("./Payment");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });

            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);
            var uzytkownik = _context.AspNetUsers.SingleOrDefault(x => x.Id.Equals(userId));
            if (uzytkownik.PortfelId == null) return RedirectToPage("./Payment");

            AspNetUsers = await _context.AspNetUsers
                .Include(z => z.Portfel).ToListAsync();
            return Page();
        }
    }
}
