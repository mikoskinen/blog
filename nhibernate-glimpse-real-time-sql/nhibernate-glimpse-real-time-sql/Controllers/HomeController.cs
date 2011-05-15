using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using nhibernate_glimpse_real_time_sql.Models;

namespace nhibernate_glimpse_real_time_sql.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var glimpseLocation = HttpContext.Request.Url.OriginalString + @"glimpse/config";

            ViewBag.Message = "This site executes SQL with NHibernate. Enable the Glimpse to see the executed SQL-queries in real-time. Glimpse can be enabled by visiting " + glimpseLocation;

            ExecuteQueryWithNHibernate();

            return View();
        }

        private void ExecuteQueryWithNHibernate()
        {
            var session = MvcApplication.CreateSession();

            var clients = session.Query<Client>()
                .ToList();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
