﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SUB.Data;
using SUB.Models;

namespace SUB.Pages.Contact
{
    public class ListModel : PageModel
    {
        private readonly SUB.Data.SUBContext _context;

        public ListModel(SUB.Data.SUBContext context)
        {
            _context = context;
        }

        public IList<Zgloszenie> Zgloszenie { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToPage("/Account/Login", new { area = "Identity" });
            Zgloszenie = await _context.Zgloszenie
                .Include(z => z.Uzytkownik).ToListAsync();
            return Page();
        }
    }
}
