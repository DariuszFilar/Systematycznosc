using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Systematycznosc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult MorningQuestions()
        {
            ViewBag.Message = "MorningQuestions.";

            return View();
        }
        public ActionResult EveningQuestions()
        {
            ViewBag.Message = "EveningQuestions.";

            return View();
        }
        public ActionResult Goals()
        {
            ViewBag.Message = "Goals.";

            return View();
        }
        public ActionResult TODO()
        {
            ViewBag.Message = "TODO.";

            return View();
        }
    }
}