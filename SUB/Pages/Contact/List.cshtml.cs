using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Contact
{
    public class ListModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ListModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Zgloszenie> Zgloszenie { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });
            if (User.IsInRole("TechnicalTeam"))
            {
                Zgloszenie = await _context.Zgloszenie.Include(z => z.Uzytkownik).ToListAsync();
            }
            else
            {
                Zgloszenie = await _context.Zgloszenie.Include(z => z.Uzytkownik).Where(x => x.UzytkownikId.Equals(_userManager.GetUserId(User))).ToListAsync();
            }


            return Page();
        }
    }
}
