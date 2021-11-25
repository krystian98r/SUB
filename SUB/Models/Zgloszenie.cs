using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SUB.Models
{
    public class Zgloszenie
    {
        public int Id { get; set; }
        /// <summary>
        /// Pobiera lub ustawia identyfikator użytkownika dla zgłoszenia.
        /// </summary>
        /// <value>
        /// Identyfikator użytkownika - połączenie z tabelą AspNetUser
        /// </value>
        [Display(Name = "Identyfikator użytkownika")]
        public String? UzytkownikId { get; set; }
        /// <summary>
        /// Pobiera lub ustawia użytkownika dla zgłoszenia
        /// </summary>
        /// <value>
        /// Identyfikator użytkownika - połączenie z tabelą AspNetUser
        /// </value>
        [ForeignKey("UzytkownikId")]
        public AspNetUsers Uzytkownik { get; set; }
        /// <summary>
        /// Pobiera lub ustawia email.
        /// </summary>
        /// <value>
        /// Adres email przypisany do zgłoszenia.
        /// </value>
        [Required(ErrorMessage = "Pole jest wymagane<br>Na ten adres otrzymasz odpowiedź")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres e-mail")]
        [Display(Name = "Adres e-mail")]
        public String Email { get; set; }
        /// <summary>
        /// Pobiera lub ustawia treść.
        /// </summary>
        /// <value>
        /// Treść zgłoszenia.
        /// </value>
        [Required(ErrorMessage = "Podaj treść zgłoszenia")]
        [Display(Name = "Treść zgłoszenia")]
        public String Tresc { get; set; }
        /// <summary>
        /// Pobiera lub ustawia kategorie zgłoszenia.
        /// </summary>
        /// <value>
        /// Kategoria zgłoszenia.
        /// </value>
        [Required(ErrorMessage = "Wybierz kategorie zgłoszenia")]
        public String Kategoria { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// Status zgłoszenia, przyjmuje wartości:
        /// "Przyjęte"
        /// "W realizacji"
        /// "Zakończone"
        /// </value>
        public String Status { get; set; }
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataUtworzenia { get; set; }
    }
}
