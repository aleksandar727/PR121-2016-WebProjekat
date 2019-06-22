using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Lokacija
    {
        #region Fields
        public decimal GeografskaSirina { get; set; } // decimal zbog preciznosti
        public decimal GeografskaDuzina { get; set; }
        public Adresa Adresa { get; set; }
        #endregion

        #region Constructors
        public Lokacija()
        {
            this.GeografskaDuzina = 0;
            this.GeografskaSirina = 0;
            this.Adresa = new Adresa();
        }
        #endregion

        #region Methods
        public override string ToString() // Sirina pa Duzina
        {
            return $"{Adresa.ToString()} {GeografskaSirina} {GeografskaDuzina}";
        }
        #endregion
    }
}