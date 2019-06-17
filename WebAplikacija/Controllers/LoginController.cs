using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplikacija.Models;
using WebAplikacija.Models.PomocneKlase;

namespace WebAplikacija.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
        public ActionResult Login()
        {
            Korisnici korisnici = (Korisnici)HttpContext.Application["Korisnici"];
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (korisnik == null)
            {
                korisnik = new Korisnik();
                Session["Korisnik"] = korisnik;
            }

            if (!string.IsNullOrEmpty(Request["KorisnickoIme"]) && !string.IsNullOrEmpty(Request["Lozinka"]))
            {
                if (korisnici.dictionaryKorisnici.ContainsKey(Request["KorisnickoIme"]))
                {
                    if (korisnici.dictionaryKorisnici[Request["KorisnickoIme"]].Lozinka.Equals(Request["Lozinka"]))
                    {
                        korisnik = korisnici.dictionaryKorisnici[Request["KorisnickoIme"]];
                        korisnik.LoggedIn = true;
                        DateTime TryDate;
                        DateTime.TryParse(Request["LoggingDate"], out TryDate);
                        korisnik.LoggingDate = TryDate;
                    }
                    else
                        ViewBag.Message = "Pogresno korisnicko ime ili lozinka";
                }
                else
                    ViewBag.Message = "Pogresno korisnicko ime ili lozinka";
            }
            else
                ViewBag.Message = "Niste popunili polja!";

            ViewBag.Korisnik = korisnik;
            return View("Result");
        }
    }
}