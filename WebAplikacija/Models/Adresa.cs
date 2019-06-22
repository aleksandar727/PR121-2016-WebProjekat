using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Adresa
    {
        #region Fields
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string NaseljenoMesto {get; set;}
        public int PostarinskiBroj { get; set; }
        #endregion

        #region Constructors
        public Adresa()
        {
            this.Ulica = "";
            this.Broj = 0;
            this.NaseljenoMesto = "";
            this.PostarinskiBroj = 0;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Ulica} {Broj} {NaseljenoMesto} {PostarinskiBroj}";
        }
        #endregion
    }
}