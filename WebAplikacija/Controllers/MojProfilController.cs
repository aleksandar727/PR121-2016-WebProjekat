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

            if(!string.IsNullOrEmpty(Request["Ime"]))
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
    }
}