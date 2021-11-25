using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;

namespace SUB.Pages.Wallet
{
    public class PaymentModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        [Display(Name = "Kwota do³adowania")]
        [Range(10, 999999, ErrorMessage = "Wp³aæ minimum 10 PLN")]
        public double Wplata { get; set; }

        public AspNetUsers Uzytkownik { get; set; }

        [BindProperty]
        public Portfel Portfel { get; set; }

        public HistoriaPortfela HistoriaPortfela { get; set; }

        public PaymentModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
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

            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);

            Uzytkownik = _context.AspNetUsers.SingleOrDefault(x => x.Id.Equals(userId));

            if (Uzytkownik.PortfelId == null)
            {
                _context.Portfel.Add(Portfel);
                await _context.SaveChangesAsync();
                Uzytkownik.PortfelId = Portfel.Id;
                await _context.SaveChangesAsync();
            }
            else
            {
                Portfel.Srodki = Math.Round(Portfel.Srodki + Wplata, 2);
                _context.Attach(Portfel).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                HistoriaPortfela = new HistoriaPortfela((int)Uzytkownik.PortfelId, Wplata, Portfel.Srodki, "Wp³ata");
                _context.HistoriaPortfela.Add(HistoriaPortfela);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Payment");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });

            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);

            Uzytkownik = _context.AspNetUsers.SingleOrDefault(x => x.Id.Equals(userId));
            Portfel = await _context.Portfel.FirstOrDefaultAsync(x => x.Id == Uzytkownik.PortfelId);

            return Page();
        }
    }
}
