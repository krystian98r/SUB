using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SUB.Pages
{
    /// <summary>
    /// Klasa reprezentuj¹ca podstronê "Portfel" oraz jej funckje
    /// </summary>
    public class WalletModel : PageModel
    {
        public void OnGet()
        {
        }
        /// <summary>Metoda dodaj¹ca œrodki do portfela</summary>
        /// <param name="srodki">Iloœæ funduszy wp³acana do portfela.</param>
        public void DoladujSrodki (double srodki)
        {

        }
        /// <summary>
        /// Metoda wyp³acaj¹ca œrodki z portfela na zewnêtrzne konto
        /// </summary>
        /// <param name="srodki">Iloœæ funduszy wyp³acanych z portfela</param>
        /// <param name="numerKonta"></param>
        public void WyplacSrodki (double srodki, String numerKonta)
        {

        }
    }
}
