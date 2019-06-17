using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebAplikacija.Models.PomocneKlase
{
    public class Korisnici
    {
        public Dictionary<string, Korisnik> dictionaryKorisnici { get; set; }

        #region Constructors
        public Korisnici() { dictionaryKorisnici = new Dictionary<string, Korisnik>(); }
        public Korisnici(string putanja)
        {
            dictionaryKorisnici = new Dictionary<string, Korisnik>();
            putanja = HostingEnvironment.MapPath(putanja);

            FileStream stream = new FileStream(putanja, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null) // JohnLast;JohnLastPass;John;Last;Guest;Apartman1 Apartman2 Apartman3;Rezervacija1 Rezervacija2
            {
                string[] uT = line.Split(';'); // uT - Ucitani Text
                Korisnik korisnik = new Korisnik(uT[0], uT[1], uT[2], uT[3]);
            }

        }
        #endregion 
    }
}