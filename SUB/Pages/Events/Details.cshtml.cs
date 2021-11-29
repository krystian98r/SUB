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

namespace SUB.Areas.Events.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Wydarzenie Wydarzenie { get; set; }
        public IList<Kupon> Kupon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (id == null)
            {
                return NotFound();
            }

            Wydarzenie = await _context.Wydarzenie.FirstOrDefaultAsync(m => m.Id == id);

            if (User.IsInRole("BookmakerObserver"))
            {
                Kupon = await _context.Kupon.Include(k => k.Uzytkownik).Include(k => k.Wydarzenie).Where(x => x.WydarzenieId == id).OrderByDescending(x => x.DataUtworzenia).ToListAsync();
            }
            else
            {
                Kupon = await _context.Kupon.Include(k => k.Uzytkownik)
                .Include(k => k.Wydarzenie).Where(x => x.UzytkownikId.Equals(_userManager.GetUserId(User)) && x.WydarzenieId == id).OrderByDescending(x => x.DataUtworzenia).ToListAsync();
            }


            if (Wydarzenie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
