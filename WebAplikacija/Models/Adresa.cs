using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Adresa
    {
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string NaseljenoMesto {get; set;}
        public int PostarinskiBroj { get; set; }

        public override string ToString()
        {
            return $"{Ulica} {Broj} {NaseljenoMesto} {PostarinskiBroj}";
        }
    }
}