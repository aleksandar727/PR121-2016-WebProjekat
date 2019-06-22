using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Rezervacija
    {
        #region Fields
        public Apartman Apartman { get; set; }
        public DateTime PocetniDatumRezervacije { get; set; }
        public int BrojNocenja { get; set; } = 1;
        public double UkupnaCena { get => Apartman.CenaPoNoci * BrojNocenja; set => UkupnaCena = value; }
        public Korisnik Gost { get; set; }
        public StatusRezervacije StatusRezervacije { get; set; }
        #endregion

        #region Constructors
        public Rezervacija()
        {
            this.Apartman = new Apartman();
            this.PocetniDatumRezervacije = new DateTime();
            this.BrojNocenja = 0;
            this.UkupnaCena = 0;
            this.Gost = new Korisnik();
            this.StatusRezervacije = StatusRezervacije.Kreirana;
        }
        #endregion
    }

    public enum StatusRezervacije
    {
        Kreirana,
        Odbijena,
        Odustanak,
        Prihvacena,
        Zavrsena
    }
}