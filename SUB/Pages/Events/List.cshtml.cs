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
    public class IndexModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public IndexModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        public IList<Wydarzenie> Wydarzenie { get;set; }

        public async Task OnGetAsync()
        {
            Wydarzenie = await _context.Wydarzenie.ToListAsync();
        }
    }
}
