using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Coupons
{
    public class IndexModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public IndexModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        public IList<Kupon> Kupon { get;set; }

        public async Task OnGetAsync()
        {
            Kupon = await _context.Kupon
                .Include(k => k.Wydarzenie).ToListAsync();
        }
    }
}
