using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAplikacija.Models.PomocneKlase;

namespace WebAplikacija.Models
{
    public class Korisnik
    {
        #region Fields
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public UlogaKorisnika UlogaKorisnika { get; set; }
        public List<Apartman> Apartmani { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }

        public bool LoggedIn { get; set; } = false;
        public DateTime LoggingDate { get; set; }
        
        #endregion

        #region Constructors
        public Korisnik()
        {
            this.KorisnickoIme = "";
            this.Lozinka = "";
            this.Ime = "";
            this.Prezime = "";
            //this.LoggingDate = DateTime.Now;
            this.Apartmani = new List<Apartman>();
            this.Rezervacije = new List<Rezervacija>();
            this.LoggedIn = false;
            this.UlogaKorisnika = UlogaKorisnika.Neulogovan;
        }
        public Korisnik(string KorisnickoIme, string Lozinka, string Ime, string Prezime, UlogaKorisnika UlogaKorisnika, List<Apartman> Apartmani, List<Rezervacija> Rezervacije) : this()
        {
            this.KorisnickoIme = KorisnickoIme;
            this.Lozinka = Lozinka;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.UlogaKorisnika = UlogaKorisnika;
            this.Apartmani = Apartmani;
            this.Rezervacije = Rezervacije;
            this.LoggedIn = false;
        }

        public Korisnik(string KorisnickoIme, string Lozinka, string Ime, string Prezime) : this()
        {
            this.KorisnickoIme = KorisnickoIme;
            this.Lozinka = Lozinka;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Apartmani = new List<Apartman>();
            this.Rezervacije = new List<Rezervacija>();
            this.LoggedIn = false;
        }
        #endregion

        #region Methods
        /*public void LogOff()
        {
            KorisnickoIme = "";
            Lozinka = "";
            Ime = "";
            Prezime = "";
            this.Apartmani = null;
            this.Rezervacije = null;
            LoggedIn = false;
        }*/
        public bool IsAdmin()
        {
            return UlogaKorisnika == UlogaKorisnika.Administrator;
        }

        public bool IsDomacin()
        {
            return UlogaKorisnika == UlogaKorisnika.Domacin;
        }

        public bool IsGost()
        {
            return UlogaKorisnika == UlogaKorisnika.Gost;
        }
        

        public override string ToString()
        {
            return $"{KorisnickoIme} {Lozinka} {Ime} {Prezime} {UlogaKorisnika} '{ExtensionMethods.ExtendedToString(Apartmani)}' '{ExtensionMethods.ExtendedToString(Rezervacije)}'";
        }
        #endregion  
    }

    public enum UlogaKorisnika
    {
        Gost,
        Administrator,
        Domacin,
        Neulogovan
    }
}