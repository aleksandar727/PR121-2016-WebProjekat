using System;
using System.Collections.Generic;
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
            if(!korisnik.LoggedIn)
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
                Korisnici.dictionaryKorisnici[korisnik.KorisnickoIme].Ime = Request["Ime"];
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
    }
}