using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplikacija.Models;
using WebAplikacija.Models.PomocneKlase;

namespace WebAplikacija.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if(korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            ViewBag.Korisnik = korisnik;
            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if(korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }
            if(!string.IsNullOrEmpty(Request["Ime"]) && !string.IsNullOrEmpty(Request["Prezime"]) && !string.IsNullOrEmpty(Request["KorisnickoIme"]) && !string.IsNullOrEmpty(Request["Lozinka"]))
            {
                if(!Korisnici.dictionaryKorisnici.ContainsKey(Request["KorisnickoIme"]))
                {
                    korisnik.KorisnickoIme = Request["KorisnickoIme"];
                    korisnik.Ime = Request["Ime"];
                    korisnik.Prezime = Request["Prezime"];
                    korisnik.Lozinka = Request["Lozinka"];
                    korisnik.UlogaKorisnika = UlogaKorisnika.Gost;
                    korisnik.LoggedIn = true;
                    DateTime TryDate;
                    DateTime.TryParse(Request["LoggingDate"], out TryDate);
                    korisnik.LoggingDate = TryDate;
                }
                else
                {
                    ViewBag.Message = "Korisnicko ime je vec zauzeto!";
                }
                
            }
            ViewBag.Korisnik = korisnik;
            return View("Result");
        }

        public ActionResult SignOff()
        {
            Session.Abandon();
            Korisnik korisnik = new Korisnik();
            Session["Korisnik"] = korisnik;
            ViewBag.Korisnik = korisnik;
            return View("Index");
        }
    }
}