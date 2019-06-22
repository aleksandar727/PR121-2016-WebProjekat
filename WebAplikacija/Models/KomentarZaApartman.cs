using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class KomentarZaApartman
    {
        #region Fields
        public Korisnik GostKojiJeOstavioKomentar { get; set; }
        public Apartman ApartmanNaKojiSeOdnosiKomentar { get; set; }
        public string Tekst { get; set; }
        public double OcenaZaApartman { get; set; }
        #endregion

        #region Constructors
        public KomentarZaApartman()
        {
            this.GostKojiJeOstavioKomentar = new Korisnik();
            this.ApartmanNaKojiSeOdnosiKomentar = new Apartman();
            this.Tekst = "";
            this.OcenaZaApartman = 0;
        }
        public KomentarZaApartman(Korisnik GostKojiJeOstavioKomentar, Apartman ApartmanNaKojiSeOdnosiKomentar, string Tekst, double OcenaZaApartman)
        {
            this.GostKojiJeOstavioKomentar = GostKojiJeOstavioKomentar;
            this.ApartmanNaKojiSeOdnosiKomentar = ApartmanNaKojiSeOdnosiKomentar;
            this.Tekst = Tekst;
            this.OcenaZaApartman = OcenaZaApartman;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{GostKojiJeOstavioKomentar} {ApartmanNaKojiSeOdnosiKomentar} {Tekst} {OcenaZaApartman}";
        }
        #endregion
    }
}