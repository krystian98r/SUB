using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// <summary>
        /// Pobiera lub ustawia pole IdUzytkownik
        /// </summary>
        /// <value>
        /// Identyfikator użytkownika, do którego należy kupon.
        /// </value>
        public String IdUzytkownik { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole IdWydarzenia.
        /// </summary>
        /// <value>
        /// Identyfikator wydarzenia, którego dotyczy kupon.
        /// </value>
        public int IdWydarzenie { get; set; }
        /// <summary>
        /// Pobiera lub ustawia pole Srodki.
        /// </summary>
        /// <value>
        /// Środki przeznaczone na utworzenie tego kuponu.
        /// </value>
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
        public int ObstawionyKurs { get; set; }
    }
}
