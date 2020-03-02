using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Systematycznosc.ViewModels;

namespace Systematycznosc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private SystematycznoscContext _context;
        public HomeController() { _context = new SystematycznoscContext(); }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Credo()
        {
            CredoViewModel model = new CredoViewModel();
            return View(model);
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Questions()
        {
            return View();
        }
        public ActionResult Goals()
        {
            return View();
        }
        public ActionResult TODO()
        {
            return View();
        }
    }
}