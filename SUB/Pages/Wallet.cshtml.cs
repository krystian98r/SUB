using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SUB.Pages
{
    /// <summary>
    /// Klasa reprezentuj�ca podstron� "Portfel" oraz jej funckje
    /// </summary>
    public class WalletModel : PageModel
    {
        public void OnGet()
        {
        }
        /// <summary>Metoda dodaj�ca �rodki do portfela</summary>
        /// <param name="srodki">Ilo�� funduszy wp�acana do portfela.</param>
        public void DoladujSrodki (double srodki)
        {

        }
        /// <summary>
        /// Metoda wyp�acaj�ca �rodki z portfela na zewn�trzne konto
        /// </summary>
        /// <param name="srodki">Ilo�� funduszy wyp�acanych z portfela</param>
        /// <param name="numerKonta"></param>
        public void WyplacSrodki (double srodki, String numerKonta)
        {

        }
    }
}
