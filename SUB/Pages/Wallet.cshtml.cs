using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUB.Models;

namespace SUB.Pages
{
    /// <summary>
    /// Klasa reprezentuj¹ca podstronê "Portfel" oraz jej funckje
    /// </summary>
    public class WalletModel : PageModel
    {
        [BindProperty]
        public Portfel Portfel { get; set; }
        public double Srodki { get; set; }
        
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            // Tutaj zapisz model do bazy danych

            return RedirectToPage("/Index", new { Portfel.Srodki });
        }
    }
}
