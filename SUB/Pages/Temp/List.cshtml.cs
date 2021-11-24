using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Temp
{
    public class ListModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public ListModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        public IList<Portfel> Portfel { get;set; }

        public async Task OnGetAsync()
        {
            Portfel = await _context.Portfel.ToListAsync();
        }
    }
}
