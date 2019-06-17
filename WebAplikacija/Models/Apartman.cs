using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using WebAplikacija.Models.PomocneKlase;

namespace WebAplikacija.Models
{
    public class Apartman
    {
        #region Fields
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
        #endregion

        #region Constructors
        /*public Apartman(string TipApartmana, int BrojSoba, int BrojGostiju, ) // Slozene tipove posebno
        {

        }*/
        #endregion

        #region Methods
        public override string ToString()
        {
            string imageAsString = "";
            foreach(var s in SlikeApartmana)
            {
                byte[] arr;
                using (MemoryStream ms = new MemoryStream())
                {
                    s.Save(ms, ImageFormat.Jpeg);
                    arr = ms.ToArray();
                    imageAsString += arr + " ";
                }
            }

            return $"{TipApartmana} {BrojSoba} {BrojGostiju} |{Lokacija}| ~{ExtensionMethods.ExtendedToString(DatumiZaIzdavanje)}~ ~{ExtensionMethods.ExtendedToString(DostupnostPoDatumima)}~ ~{Domacin}~ " +
                $"~{ExtensionMethods.ExtendedToString(KomentariGostiju)}~ ~{imageAsString}~ {CenaPoNoci} {VremeZaPrijavu} {VremeZaOdjavu} {Status} ~{ExtensionMethods.ExtendedToString(ListaSadrzajaApartmana)}~ " +
                $"~{ExtensionMethods.ExtendedToString(Rezervacije)}~";
        }

        
        #endregion  
    }

    public enum Status
    {
        Aktivno,
        Neaktivno
    }
}