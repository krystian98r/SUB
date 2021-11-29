using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Coupons
{
    public class ListModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration Configuration;

        public ListModel(SUB.Data.SUBContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            Configuration = configuration;
        }

        public PaginatedList<Kupon> Kupon { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? pageIndex, string currentFilter, string searchString)
        {
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Kupon> query = from s in _context.Kupon select s;

            if (User.IsInRole("BookmakerObserver"))
            {
                query = query.Include(k => k.Uzytkownik).Include(k => k.Wydarzenie).OrderByDescending(x => x.DataUtworzenia);
            }
            else
            {
                query = query.Include(k => k.Uzytkownik).Include(k => k.Wydarzenie).Where(s => s.UzytkownikId.Equals(_userManager.GetUserId(User))).OrderByDescending(x => x.DataUtworzenia);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Include(k => k.Wydarzenie).Where(s => s.Wydarzenie.Gosc.Contains(searchString) || s.Wydarzenie.Gospodarz.Contains(searchString) || s.Srodki.ToString().Contains(searchString) || s.Wydarzenie.Data.ToString().Contains(searchString) || s.Uzytkownik.UserName.Contains(searchString));
            }
            var pageSize = Configuration.GetValue("PageSize", 4);
            Kupon = await PaginatedList<Kupon>.CreateAsync(query.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
