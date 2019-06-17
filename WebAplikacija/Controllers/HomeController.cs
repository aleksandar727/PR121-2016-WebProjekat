using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}