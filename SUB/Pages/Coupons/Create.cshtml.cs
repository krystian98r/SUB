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
        public string ErrorMsg { get; set; }
        [BindProperty]
        public Wydarzenie Wydarzenie { get; set; }
        [BindProperty]
        public Kupon Kupon { get; set; }
        public HistoriaPortfela HistoriaPortfela { get; set; }

        public CreateModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });

            if (id == null)
            {
                ViewData["WydarzenieId"] = new SelectList(_context.Wydarzenie.Where(x => x.Data > DateTime.Now).OrderBy(s => s.Data), "Id", "SkrotWydarzenia");
            }
            else
            {
                Wydarzenie = await _context.Wydarzenie.FirstOrDefaultAsync(m => m.Id == id);
                Kupon = new Kupon();
                if(Wydarzenie != null) Kupon.WydarzenieId = Wydarzenie.Id;
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);

            Uzytkownik = _context.AspNetUsers.SingleOrDefault(x => x.Id.Equals(userId));
            Portfel = await _context.Portfel.FirstOrDefaultAsync(x => x.Id == Uzytkownik.PortfelId);

            if (Portfel.Srodki < Kupon.Srodki)
            {
                ErrorMsg = "Niewystarczające środki na utworzenie tego kuponu!";
                return Page();
            }
            else
            {
                _context.Kupon.Add(Kupon);
                Uzytkownik.Portfel.Srodki -= Kupon.Srodki;
                await _context.SaveChangesAsync();

                HistoriaPortfela = new HistoriaPortfela((int)Uzytkownik.PortfelId, -Kupon.Srodki, Uzytkownik.Portfel.Srodki, "Zakup kuponu");
                _context.HistoriaPortfela.Add(HistoriaPortfela);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./List");
        }
    }
}
