using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplikacija.Models;
using WebAplikacija.Models.PomocneKlase;

namespace WebAplikacija.Controllers
{
    public class MojProfilController : Controller
    {
        // GET: MojProfil
        public ActionResult Index()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }
            if (!korisnik.LoggedIn)
            {
                return View("Greska");
            }

            ViewBag.Korisnik = korisnik;

            return View();
        }

        [HttpPost]
        public ActionResult Izmena()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            if (!string.IsNullOrEmpty(Request["Ime"]))
            {
                Korisnici.dictionaryKorisnici[korisnik.KorisnickoIme].Ime = Request["Ime"]; // Greska ovde, pogledaj kasnije
            }

            if (!string.IsNullOrEmpty(Request["Prezime"]))
            {
                Korisnici.dictionaryKorisnici[korisnik.KorisnickoIme].Prezime = Request["Prezime"];
            }

            if (!string.IsNullOrEmpty(Request["Lozinka"]))
            {
                Korisnici.dictionaryKorisnici[korisnik.KorisnickoIme].Lozinka = Request["Lozinka"];
            }

            if (!string.IsNullOrEmpty(Request["KorisnickoIme"]))
            {
                Korisnici.dictionaryKorisnici[korisnik.KorisnickoIme].KorisnickoIme = Request["KorisnickoIme"];
                var key = "";
                foreach (var item in Korisnici.dictionaryKorisnici)
                {
                    if (item.Value == korisnik)
                    {
                        key = item.Key;
                        break;
                    }
                }

                Korisnici.dictionaryKorisnici.Remove(key);
                Korisnici.dictionaryKorisnici.Add(Request["KorisnickoIme"], korisnik);
            }

            Session["Korisnik"] = korisnik;
            ViewBag.Korisnik = korisnik;

            return View("Index");
        }

        public ActionResult ListajKorisnike()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            if (!korisnik.IsAdmin())
            {
                return View("Greska");
            }

            List<Korisnik> listajKorisnikeList = new List<Korisnik>();
            var listajKorisnike = Korisnici.dictionaryKorisnici.Values.ToArray();
            Array.Sort(listajKorisnike, (x, y) => String.Compare(x.UlogaKorisnika.ToString(), y.UlogaKorisnika.ToString()));

            listajKorisnikeList = listajKorisnike.ToList();

            ViewBag.ListajKorisnikeList = listajKorisnikeList;
            ViewBag.Korisnik = korisnik;
            List<string> ulogeKorisnika = new List<string>() { "Administrator", "Domacin", "Gost" };
            ViewBag.UlogeKorisnika = ulogeKorisnika;

            return View();
        }

        [HttpPost]
        public ActionResult MenjajUlogu()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            string prikupljeniPodaci = Request["UlogaKorisnika"];
            string[] splitovaniPodaci = prikupljeniPodaci.Split(',');
            int i = 0;
            foreach (var s in Korisnici.dictionaryKorisnici.Values)
            {
                if (!s.UlogaKorisnika.ToString().Equals(splitovaniPodaci[i]))
                {
                    Enum.TryParse(splitovaniPodaci[i], out UlogaKorisnika ulogaKorisnika);
                    s.UlogaKorisnika = ulogaKorisnika;
                }
                i++;
            }

            List<Korisnik> listajKorisnikeList = new List<Korisnik>();
            var listajKorisnike = Korisnici.dictionaryKorisnici.Values.ToArray();
            Array.Sort(listajKorisnike, (x, y) => String.Compare(x.UlogaKorisnika.ToString(), y.UlogaKorisnika.ToString()));

            listajKorisnikeList = listajKorisnike.ToList();

            ViewBag.ListajKorisnikeList = listajKorisnikeList;
            ViewBag.Korisnik = korisnik;
            List<string> ulogeKorisnika = new List<string>() { "Administrator", "Domacin", "Gost" };
            ViewBag.UlogeKorisnika = ulogeKorisnika;

            return View("ListajKorisnike");
        }

        public ActionResult ListajApartmane()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            /*if (korisnik.UlogaKorisnika == UlogaKorisnika.Gost)
                return View("Greska");*/
            List<Apartman> apartmani = new List<Apartman>();

            foreach (var Korisnik in Korisnici.dictionaryKorisnici.Values)
            {
                if (Korisnik.UlogaKorisnika == UlogaKorisnika.Domacin)
                {
                    foreach (var Apartman in Korisnik.Apartmani)
                    {
                        apartmani.Add(Apartman);

                    }
                }
            }


            //ViewBag.Apartmani = apartmani;
            //ViewBag.Rezervacije = korisnik.Rezervacije;
            ViewBag.Korisnik = korisnik;
            return View(apartmani);
        }

        public ActionResult MojiApartmani()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            if (korisnik.UlogaKorisnika != UlogaKorisnika.Domacin)
                return View("Greska");
            List<Apartman> apartmani = new List<Apartman>();

            foreach (var Apartman in korisnik.Apartmani)
            {
                apartmani.Add(Apartman);
            }


            //ViewBag.Apartmani = apartmani;
            //ViewBag.Rezervacije = korisnik.Rezervacije;
            ViewBag.Korisnik = korisnik;          
            return View(apartmani);
        }

        // Get: /MojProfil/Detalji?id=0
        public ActionResult Detalji()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }


            Apartman izabraniApartman = null;
            List<Apartman> apartmani = new List<Apartman>();

            foreach (var Korisnik in Korisnici.dictionaryKorisnici.Values)
            {
                if (Korisnik.UlogaKorisnika == UlogaKorisnika.Domacin)
                {
                    foreach (var Apartman in Korisnik.Apartmani)
                    {
                        apartmani.Add(Apartman);

                    }
                }
            }

            try
            {
                izabraniApartman = apartmani.ElementAt(int.Parse(Request["id"]));
            }
            catch(Exception e) { }

            ViewBag.Korisnik = korisnik;

            if (izabraniApartman == null)
            {
                
                return View("Greska");
            }

            
            return View(izabraniApartman);
        }

        public ActionResult DodajApartman() // Prikaz forme
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            ViewBag.Korisnik = korisnik;

            //return View("DodajNoviApartman");
            return View("DodajNoviApartman");
        }

        [HttpPost]
        public ActionResult DodajNoviApartman()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            if (korisnik.UlogaKorisnika != UlogaKorisnika.Domacin)
                return View("Greska");

            int ErrorMessageCount = 0;
            Apartman apartman = new Apartman();


            if (!string.IsNullOrEmpty(Request["TipApartmana"]))
            {
                apartman.TipApartmana = Request["TipApartmana"];
            }
            else
            {
                ViewBag.ErrorMessageTipApartmana = "Niste uneli tip apartmana.";
                ErrorMessageCount++;
            }


            if (!string.IsNullOrEmpty(Request["BrojSoba"]))
            {
                if (int.TryParse(Request["BrojSoba"], out int brojSoba))
                {
                    apartman.BrojSoba = brojSoba;
                }
                else
                {
                    ViewBag.ErrorMessageBrojSoba = "Niste uneli broj (Soba).";
                    ErrorMessageCount++;
                }
            }
            else
            {
                ViewBag.ErrorMessageBrojSoba = "Niste uneli broj soba.";
                ErrorMessageCount++;
            }

            if (!string.IsNullOrEmpty(Request["BrojGostiju"])) // Greska
            {
                if (int.TryParse(Request["BrojGostiju"], out int brojGostiju))
                {
                    apartman.BrojGostiju = brojGostiju;
                }
                else
                {
                    ViewBag.ErrorMessageBrojSoba = "Niste uneli broj (Gostiju).";
                    ErrorMessageCount++;
                }
            }
            else
            {
                ViewBag.ErrorMessageBrojGostiju = "Niste uneli broj gostiju.";
                ErrorMessageCount++;
            }

            // OVDE  Ćirila i Metodija 3, Novi Sad, Serbia
            if (!string.IsNullOrEmpty(Request["addr"])) // Greska
            {
                //"11, Cirila i Metodija, Телеп, Нови Сад, Novi Sad, Novi Sad City, South Backa Administrative District, Vojvodina, 21102, Serbia"
                string[] address = Request["addr"].Split(',');
                string longitude = Request["lon"];
                string latitude = Request["lat"];

                if (int.TryParse(address[0], out int broj))
                {
                    apartman.Lokacija.Adresa.Broj = broj;
                }
                else
                {
                    ViewBag.ErrorMessageLokacija = "Niste uneli broj adrese.";
                    ErrorMessageCount++;
                }


                apartman.Lokacija.Adresa.Ulica = address[1];
                apartman.Lokacija.Adresa.NaseljenoMesto = address[4];
                if (int.TryParse(address[address.Count() - 2], out int postarinskiBroj))
                {
                    apartman.Lokacija.Adresa.PostarinskiBroj = postarinskiBroj;
                }
                else
                {
                    ViewBag.ErrorMessageLokacija += " Niste uneli postarinski broj adrese.";
                    ErrorMessageCount++;
                }

                if (decimal.TryParse(longitude, out decimal geofDuzina))
                {
                    apartman.Lokacija.GeografskaDuzina = geofDuzina;
                }
                else
                {
                    ViewBag.ErrorMessageLokacija += " Niste uneli lokaciju apartmana.";
                    ErrorMessageCount++;
                }

                if (decimal.TryParse(latitude, out decimal geofSirina))
                {
                    apartman.Lokacija.GeografskaDuzina = geofSirina;
                }
                else
                {
                    ViewBag.ErrorMessageLokacija += " Niste uneli lokaciju apartmana.";
                    ErrorMessageCount++;
                }

            }
            else
            {
                ViewBag.ErrorMessageLokacija = "Niste uneli lokaciju apartmana.";
                ErrorMessageCount++;
            }

            if (!string.IsNullOrEmpty(Request["DatumiZaIzdavanje"]))
            {
                string[] splitovaniDatumi = Request["DatumiZaIzdavanje"].Split('-');

                if (DateTime.TryParse(splitovaniDatumi[0], out DateTime pocetniDatum))
                {
                    if (DateTime.TryParse(splitovaniDatumi[1], out DateTime krajnjiDatum))
                    {
                        foreach (DateTime dan in EachDay(pocetniDatum, krajnjiDatum.Date))
                        {
                            apartman.DatumiZaIzdavanje.Add(dan);
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessageDatumiZaIzdavanje = "Greska kod unosa krajnjeg datuma.";
                        ErrorMessageCount++;
                    }
                }
                else
                {
                    ViewBag.ErrorMessageDatumiZaIzdavanje = "Greska kod unosa pocetnog datuma.";
                    ErrorMessageCount++;
                }
            }
            else
            {
                ViewBag.ErrorMessageDatumiZaIzdavanje = "Niste uneli dostupne datume.";
                ErrorMessageCount++;
            }

            if (!string.IsNullOrEmpty(Request["CenaPoNoci"]))
            {
                if (double.TryParse(Request["CenaPoNoci"], out double CenaPoNoci))
                {
                    apartman.CenaPoNoci = CenaPoNoci;
                }
                else
                {
                    ViewBag.ErrorMessageCenaPoNoci = "Niste uneli vrednost (Cena po noci).";
                    ErrorMessageCount++;
                }
            }
            else
            {
                ViewBag.ErrorMessageCenaPoNoci = "Niste uneli vrednost.";
                ErrorMessageCount++;
            }

            if (!string.IsNullOrEmpty(Request["VremeZaPrijavu"]))
            {
                apartman.VremeZaPrijavu = Request["VremeZaPrijavu"];
                if (!apartman.VremeZaPrijavu.Contains("PM"))
                {
                    apartman.VremeZaPrijavu += " PM";
                }
            }
            else
            {
                ViewBag.ErrorMessageVremeZaPrijavu = "Niste uneli vreme za prijavu.";
                ErrorMessageCount++;
            }

            if (!string.IsNullOrEmpty(Request["VremeZaOdjavu"]))
            {
                apartman.VremeZaOdjavu = Request["VremeZaOdjavu"];
                if (!apartman.VremeZaOdjavu.Contains("AM"))
                {
                    apartman.VremeZaOdjavu += " AM";
                }
            }
            else
            {
                ViewBag.ErrorMessageVremeZaOdjavu = "Niste uneli vreme za odjavu.";
                ErrorMessageCount++;
            }

            if (!string.IsNullOrEmpty(Request["ListaSadrzajaApartmana"]))
            {
                int i = 1;
                string[] splitRequest = Request["ListaSadrzajaApartmana"].Split(',');
                foreach (var s in splitRequest)
                {
                    apartman.ListaSadrzajaApartmana.Add(new SadrzajApartmana(i, s));
                    i++;
                }
            }
            else
            {
                ViewBag.ErrorMessageListaSadrzajaApartmana = "Niste uneli sadrzaj/e.";
                ErrorMessageCount++;
            }

            if (ErrorMessageCount == 0)
            {
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                            file.SaveAs(path);
                            UploadedFile uf = new UploadedFile(fileName, path);
                            apartman.SlikeApartmana.Add(uf);
                        }
                        else
                        {
                            ViewBag.ErrorMessageImages = "Niste izabrali sliku/e.";
                            ErrorMessageCount++;
                        }
                    }
                }
                else
                {
                    ViewBag.ErrorMessageImages = "Niste izabrali sliku/e.";
                    ErrorMessageCount++;
                }
            }


            if (ErrorMessageCount > 0)
            {
                ViewBag.Korisnik = korisnik;
                return View("DodajNoviApartman");
            }

            if (!Korisnici.dictionaryKorisnici[korisnik.KorisnickoIme].Apartmani.Contains(apartman))
            {
                Korisnici.dictionaryKorisnici[korisnik.KorisnickoIme].Apartmani.Add(apartman);
            }

            ViewBag.Korisnik = korisnik;
            return RedirectToAction("MojiApartmani"); 
        }

        private IEnumerable<DateTime> EachDay(DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
                yield return day;
        } // Day iteration
    }
}