using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Areas.Events.Pages
{
    public class ListModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public ListModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        public string DataSort { get; set; }

        public IList<Wydarzenie> Wydarzenie { get;set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });
            Wydarzenie = await _context.Wydarzenie.ToListAsync();

            DataSort = sortOrder == "Data" ? "data_desc" : "Date";
            IQueryable<Wydarzenie> query = from s in _context.Wydarzenie select s;

            switch(sortOrder)
            {
                case "Data":
                    query = query.OrderBy(s => s.Data);
                    break;
                case "data_desc":
                    query = query.OrderByDescending(s => s.Data);
                    break;
                default:
                    query = query.OrderBy(s => s.Data);
                    break;
            }

            Wydarzenie = await query.AsNoTracking().ToListAsync();

            return Page();
        }
    }
}
