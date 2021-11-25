using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SUB.Models
{
    public class HistoriaPortfela
    {
        public HistoriaPortfela(int portfelId, double srodki, double stanPortfela, string zdarzenie)
        {
            PortfelId = portfelId;
            Srodki = srodki;
            StanPortfela = stanPortfela;
            Zdarzenie = zdarzenie;
        }

        public int Id { get; set; }
        public Portfel Portfel { get; set; }
        public int PortfelId { get; set; }
        [Display(Name = "Środki")]
        public double Srodki { get; set; }
        [Display(Name = "Stan portfela")]
        public double StanPortfela { get; set; }
        public String Zdarzenie { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy  HH:mm}")]
        public DateTime Data { get; set; }
    }
}
