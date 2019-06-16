using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Apartman
    {
        public string TipApartmana { get; set; }
        public int BrojSoba { get; set; }
        public int BrojGostiju { get; set; }
        public Lokacija Lokacija { get; set; }
        public List<DateTime> DatumiZaIzdavanje { get; set; }
        public List<DateTime> DostupnostPoDatumima { get; set; }
        public Korisnik Domacin { get; set; }
        public List<KomentarZaApartman> KomentariGostiju { get; set; }
        public List<Image> SlikeApartmana { get; set; }
        public double CenaPoNoci { get; set; }
        public string VremeZaPrijavu { get; set; } = "2 PM";
        public string VremeZaOdjavu { get; set; } = "10 AM";
        public Status Status { get; set; }
        public List<SadrzajApartmana> ListaSadrzajaApartmana { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }
    }

    public enum Status
    {
        Aktivno,
        Neaktivno
    }
}