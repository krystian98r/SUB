using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SUB.Models
{
    public class Portfel
    {
        public int Id { get; set; }
        [Display(Name = "Środki")]
        [Range(0,999999, ErrorMessage ="Wartośc nie może być ujemna")]
        public double Srodki { get; set; }
        [Display(Name ="Kod portfela")]
        [Required(ErrorMessage ="Podanie kodu jest wymagane")]
        public string KodPortfela { get; set; }
    }
}

