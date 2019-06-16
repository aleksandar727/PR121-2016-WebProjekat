using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Lokacija
    {
        public decimal GeografskaSirina { get; set; } // decimal zbog preciznosti
        public decimal GeografskaDuzina { get; set; }
        public Adresa Adresa { get; set; }

        public override string ToString() // Sirina pa Duzina
        {
            return $"{Adresa.ToString()}{GeografskaSirina}, {GeografskaDuzina}";
        }
    }
}