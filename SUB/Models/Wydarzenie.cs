using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SUB.Models
{
    /// <summary>
    /// Klasa rezprezentująca Wydarzenie
    /// </summary>
    public class Wydarzenie
    {
        /// <summary>
        /// Pobiera lub ustawia identyfikator.
        /// </summary>
        /// <value>
        /// Identyfikator wydarzenia.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole Gospodarz.
        /// </summary>
        /// <value>
        /// Gospodarz wydarzenia sportowego.
        /// </value>
        [Required(ErrorMessage = "Pole jest wymagane")]
        public String Gospodarz { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole Gosc.
        /// </summary>
        /// <value>
        /// Gosc wydarzenia sportowego.
        /// </value>
        [Required(ErrorMessage = "Pole jest wymagane")]
        public String Gosc { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole ZwyciestwoGospodarz.
        /// </summary>
        /// <value>
        /// Obowiązujący kurs na zwycięstwo gospodarza.
        /// </value>
        public float? ZwyciestwoGospodarz { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole Gospodarz.
        /// </summary>
        /// <value>
        /// Obowiązujący kurs na zwycięstwo Gościa
        /// </value>
        public float? ZwyciestwoGosc { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole Gospodarz.
        /// </summary>
        /// <value>
        /// Obowiązujący kurs na remis.
        /// </value>
        public float? Remis { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole Gospodarz.
        /// </summary>
        /// <value>
        /// Data oraz czas wydarzenia sportowego.
        /// </value>
        [Display(Name = "Data wydarzenia")]
        [Required(ErrorMessage = "Określenie daty jest wymagane")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy  HH:mm}")]
        public DateTime Data { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole Gospodarz.
        /// </summary>
        /// <value>
        /// Wynik wydarzenia przyjmuje trzy wartości:
        /// 0 - zwycięstwo gospodarza
        /// 1 - zwycięstro gościa
        /// 2 - remis
        /// </value>
        [Display(Name = "Wynik wydarzenia")]
        [Range(0, 2, ErrorMessage = "Wprowadź jedną z wartości:<br>0 - wygrana gospodarzy<br>1 - wygrana gości<br>2 - remis")]
        public int? WynikWydarzenia { get; set; }
    }
}
