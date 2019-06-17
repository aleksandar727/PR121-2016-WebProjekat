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
        public static Dictionary<string, Korisnik> dictionaryKorisnici { get; set; } = new Dictionary<string, Korisnik>();


        #region Constructors
        public Korisnici() { }
        public Korisnici(string putanja)
        {
            dictionaryKorisnici = new Dictionary<string, Korisnik>();
            putanja = HostingEnvironment.MapPath(putanja);

            FileStream stream = new FileStream(putanja, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null) 
            {
                string[] uT = line.Split(';'); // uT - Ucitani Text
                Korisnik korisnik = new Korisnik(uT[0], uT[1], uT[2], uT[3]);
                korisnik.UlogaKorisnika = UlogaKorisnika.Administrator;
                Korisnici.dictionaryKorisnici.Add(korisnik.KorisnickoIme, korisnik);
            }
            sr.Close();
            stream.Close();
        }
        #endregion 
    }
}