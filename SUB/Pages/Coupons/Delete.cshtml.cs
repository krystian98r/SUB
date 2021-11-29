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

namespace SUB.Pages.Coupons
{
    public class DeleteModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Kupon Kupon { get; set; }
        public HistoriaPortfela HistoriaPortfela { get; set; }
        public AspNetUsers Uzytkownik { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (id == null)
            {
                return NotFound();
            }

            Kupon = await _context.Kupon
                .Include(k => k.Wydarzenie).FirstOrDefaultAsync(m => m.Id == id);

            if (Kupon.Wydarzenie.Data < DateTime.Now || (!Kupon.UzytkownikId.Equals(_userManager.GetUserId(User)) && !User.IsInRole("BookmakerObserver"))) return RedirectToPage("/Index");

            if (Kupon == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kupon = await _context.Kupon.FindAsync(id);

            if (Kupon != null)
            {
                Uzytkownik = _context.AspNetUsers.Include(k => k.Portfel).SingleOrDefault(x => x.Id == Kupon.UzytkownikId);

                if (Uzytkownik.Portfel != null)
                {
                    Uzytkownik.Portfel.Srodki += Kupon.Srodki;
                    
                    HistoriaPortfela = new HistoriaPortfela((int)Uzytkownik.PortfelId, Kupon.Srodki, Uzytkownik.Portfel.Srodki, "Zwrot kuponu");
                    _context.HistoriaPortfela.Add(HistoriaPortfela);
                }

                _context.Kupon.Remove(Kupon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./List");
        }
    }
}
