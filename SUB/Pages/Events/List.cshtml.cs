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

        public IList<Wydarzenie> Wydarzenie { get;set; }

        public async Task OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated) RedirectToPage("/Account/Login", new { area = "Identity" });
            Wydarzenie = await _context.Wydarzenie.ToListAsync();
        }
    }
}
