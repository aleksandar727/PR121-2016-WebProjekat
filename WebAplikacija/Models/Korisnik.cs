using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public UlogaKorisnika UlogaKorisnika { get; set; }
        public List<Apartman> Apartmani { get; set; }
        public List<Apartman> Rezervacije { get; set; }
            
    }

    public enum UlogaKorisnika
    {
        Administrator,
        Domacin,
        Gost
    }
}