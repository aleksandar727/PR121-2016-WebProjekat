﻿using System;
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
        public List<Apartman> Rezervacije { get; set; }

        public bool LoggedIn { get; set; }
        public DateTime LoggingDate { get; set; }
        #endregion

        #region Constructors
        public Korisnik()
        {
            this.KorisnickoIme = "";
            this.Lozinka = "";
            this.Ime = "";
            this.Prezime = "";
            this.LoggingDate = DateTime.Now;
            this.Apartmani = new List<Apartman>();
            this.Rezervacije = new List<Apartman>();
            this.LoggedIn = false;
        }
        public Korisnik(string KorisnickoIme, string Lozinka, string Ime, string Prezime, UlogaKorisnika UlogaKorisnika, List<Apartman> Apartmani, List<Apartman> Rezervacije) : this()
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
            this.Rezervacije = new List<Apartman>();
            this.LoggedIn = false;
        }
        #endregion

        #region Methods

        public bool LogIn()
        {
            if(Korisnici.dictionaryKorisnici.ContainsKey(KorisnickoIme))
            {
                if (Korisnici.dictionaryKorisnici[KorisnickoIme].Lozinka.Equals(this.Lozinka))
                {
                    LoggedIn = true;
                }
                else
                    LoggedIn = false;
            }
            else
            {
                LoggedIn = false;
            }

            return LoggedIn;
        }

        public void LogOff()
        {
            KorisnickoIme = "";
            Lozinka = "";
            Ime = "";
            Prezime = "";
            this.Apartmani = null;
            this.Rezervacije = null;
            LoggedIn = false;
        }

        public override string ToString()
        {
            return $"{KorisnickoIme} {Lozinka} {Ime} {Prezime} {UlogaKorisnika} '{ExtensionMethods.ExtendedToString(Apartmani)}' '{ExtensionMethods.ExtendedToString(Rezervacije)}'";
        }
        #endregion  
    }

    public enum UlogaKorisnika
    {
        Administrator,
        Domacin,
        Gost
    }
}