using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SUB.Data;
using SUB.Models;

namespace SUB.Areas.Events.Pages
{
    public class ListModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;
        private readonly IConfiguration Configuration;

        public ListModel(SUB.Data.SUBContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string DataSort { get; set; }
        public string GospSort { get; set; }
        public string GoscSort { get; set; }
        public string RemisSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string EventTime { get; set; }

        public PaginatedList<Wydarzenie> Wydarzenie { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, string eventTime)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });

            CurrentSort = sortOrder;
            DataSort = String.IsNullOrEmpty(sortOrder) ? "data_desc" : "";
            GospSort = sortOrder == "gosp" ? "gosp_desc" : "gosp";
            GoscSort = sortOrder == "gosc" ? "gosc_desc" : "gosc";
            RemisSort = sortOrder == "remis" ? "remis_desc" : "remis";

            if (string.IsNullOrEmpty(eventTime)) eventTime = "future";

            if(searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            EventTime = eventTime;

            IQueryable<Wydarzenie> query = from s in _context.Wydarzenie select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Gosc.Contains(searchString) || s.Gospodarz.Contains(searchString));
            }

            switch(eventTime)
            {
                case "past":
                query = query.Where(s => s.Data < DateTime.Now);
                    break;
                case "future":
                    query = query.Where(s => s.Data > DateTime.Now);
                    break;
                case "all":
                    query = query;
                    break;
                default:
                    query = query.Where(s => s.Data > DateTime.Now);
                    break;
            }
                
            switch (sortOrder)
            {
                case "gosp":
                    query = query.OrderBy(s => s.ZwyciestwoGospodarz);
                    break;
                case "gosp_desc":
                    query = query.OrderByDescending(s => s.ZwyciestwoGospodarz);
                    break;
                case "gosc":
                    query = query.OrderBy(s => s.ZwyciestwoGosc);
                    break;
                case "gosc_desc":
                    query = query.OrderByDescending(s => s.ZwyciestwoGosc);
                    break;
                case "remis":
                    query = query.OrderBy(s => s.Remis);
                    break;
                case "remis_desc":
                    query = query.OrderByDescending(s => s.Remis);
                    break;
                case "data_desc":
                    query = query.OrderByDescending(s => s.Data);
                    break;
                default:
                    query = query.OrderBy(s => s.Data);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Wydarzenie = await PaginatedList<Wydarzenie>.CreateAsync(query.AsNoTracking(), pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
