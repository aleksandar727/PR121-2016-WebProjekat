using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class KomentarZaApartman
    {
        public Korisnik GostKojiJeOstavioKomentar { get; set; }
        public Apartman ApartmanNaKojiSeOdnosiKomentar { get; set; }
        public string Tekst { get; set; }
        public double OcenaZaApartman { get; set; }
    }
}