using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Rezervacija
    {
        public Apartman Apartman { get; set; }
        public DateTime PocetniDatumRezervacije { get; set; }
        public int BrojNocenja { get; set; } = 1;
        public double UkupnaCena { get => Apartman.CenaPoNoci * BrojNocenja; set => UkupnaCena = value; }
        public Korisnik Gost { get; set; }
        public StatusRezervacije StatusRezervacije { get; set; }
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