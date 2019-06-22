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
        public List<UploadedFile> SlikeApartmana { get; set; }
        public double CenaPoNoci { get; set; }
        public string VremeZaPrijavu { get; set; } = "2 PM";
        public string VremeZaOdjavu { get; set; } = "10 AM";
        public Status Status { get; set; }
        public List<SadrzajApartmana> ListaSadrzajaApartmana { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }
        #endregion

        #region Constructors
        public Apartman()
        {
            this.TipApartmana = "";
            this.BrojSoba = 0;
            this.BrojGostiju = 0;
            this.Lokacija = new Lokacija();
            this.DatumiZaIzdavanje = new List<DateTime>();
            this.DostupnostPoDatumima = new List<DateTime>();
            this.Domacin = new Korisnik();
            this.KomentariGostiju = new List<KomentarZaApartman>();
            this.SlikeApartmana = new List<UploadedFile>();
            this.CenaPoNoci = 0;
            this.VremeZaPrijavu = "2 AM";
            this.VremeZaOdjavu = "10 AM";
            this.Status = Status.Neaktivno;
            this.ListaSadrzajaApartmana = new List<SadrzajApartmana>();
            this.Rezervacije = new List<Rezervacija>();

        }
        #endregion

        #region Methods
        /*public override string ToString()
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
        }*/

        
        #endregion  
    }

    public enum Status
    {
        Aktivno,
        Neaktivno
    }
}