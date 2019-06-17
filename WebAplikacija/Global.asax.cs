using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAplikacija.Models.PomocneKlase;

namespace WebAplikacija
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Korisnici korisnici = new Korisnici("~/App_Data/Administratori.txt");

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
