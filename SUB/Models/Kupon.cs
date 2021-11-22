using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUB.Models
{
    /// <summary>
    /// Klasa reprezentująca Kupon.
    /// </summary>
    public class Kupon
    {
        /// <summary>
        /// Pobiera lub ustawia identyfikator - pole Id.
        /// </summary>
        /// <value>
        /// Identyfikator kuponu.
        /// </value>
        public int Id { get; set; }
        [Display(Name = "Użytkownik")]
        [Required]
        public String UzytkownikId { get; set; }
        public AspNetUsers Uzytkownik { get; set; }
        [Display(Name = "Wydarzenie")]
        public int WydarzenieId { get; set; }
        [Required(ErrorMessage = "Wybierz wydarzenie")]
        public Wydarzenie Wydarzenie { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole Srodki.
        /// </summary>
        /// <value>
        /// Środki przeznaczone na utworzenie tego kuponu.
        /// </value>
        [Required(ErrorMessage = "Wybierz ilość środków jaką chcesz przeznaczyć")]
        [Display(Name = "Środki")]
        public double Srodki { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole ObstawionyKurs.
        /// </summary>
        /// <value>
        /// Obstawiony kurs przyjmuje trzy wartości:
        /// 0 - wygrana gospodarzy
        /// 1 - wygrana gości
        /// 2 - remis
        /// </value>
        [Range(0, 2, ErrorMessage = "Wybierz obstawiany wynik wydarzenia")]
        [Display(Name = "Obstawiony wynik")]
        public int ObstawionyKurs { get; set; }
    }
}
