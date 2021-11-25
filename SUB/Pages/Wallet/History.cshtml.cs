using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace SUB.Pages.Wallet
{
    public class HistoryModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration Configuration;

        public PaginatedList<HistoriaPortfela> HistoriaPortfela { get; set; }
        public AspNetUsers Uzytkownik { get; set; }

        public HistoryModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            Configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });

            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);

            Uzytkownik = _context.AspNetUsers.Include(x => x.Portfel).SingleOrDefault(y => y.Id.Equals(userId));
            //Uzytkownik = _context.AspNetUsers.SingleOrDefault(x => x.Id.Equals(userId));
            if (Uzytkownik.PortfelId == null) return RedirectToPage("./Payment");

            IQueryable<HistoriaPortfela> historiaQuery = from s in _context.HistoriaPortfela select s;
            historiaQuery = historiaQuery.Where(x => x.PortfelId.Equals(Uzytkownik.PortfelId)).OrderByDescending(y => y.Data);

            //HistoriaPortfela = await _context.HistoriaPortfela
            //    .Include(z => z.Portfel).Where(x => x.PortfelId.Equals(Uzytkownik.PortfelId)).OrderByDescending(y => y.Data).ToListAsync();
            var pageSize = Configuration.GetValue("PageSize", 4);
            HistoriaPortfela = await PaginatedList<HistoriaPortfela>.CreateAsync(historiaQuery, pageIndex ?? 1, pageSize);
            
            return Page();
        }
    }
}
