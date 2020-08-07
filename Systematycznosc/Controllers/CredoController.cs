using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Systematycznosc.Models;
using Systematycznosc.ViewModels;

namespace Systematycznosc.Controllers
{
    public class CredoController : Controller
    {
        private readonly SystematycznoscContext _context;
        public CredoController() { _context = new SystematycznoscContext(); }
        // GET: Credo
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var credos = _context.Credoes.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                CredoViewModel model = new CredoViewModel(credos);
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult Index(string credoValue)
        {
            var userId = User.Identity.GetUserId();
            var credosAmount = _context.Credoes.Where(x => x.UserProfileId == userId).Count();
            if (credosAmount < 12)
            {
                var credo = new Credo
                {
                    CredoId = _context.Credoes.Count() + 1,
                    CredoValue = credoValue,
                    UserProfileId = userId
                };
                _context.Credoes.Add(credo);
                _context.SaveChanges();

                ModelState.Clear();
                var credos = _context.Credoes.Where(x => x.UserProfileId == userId);
                CredoViewModel model = new CredoViewModel(credos);
                return PartialView("_AddCredo", model);
            }

            else
            {
                ModelState.Clear();
                var credos = _context.Credoes.Where(x => x.UserProfileId == userId);
                CredoViewModel model = new CredoViewModel(credos);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult CredoEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var credos = _context.Credoes.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                CredoViewModel model = new CredoViewModel(credos);
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult CredoEdit(CredoViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var credos = _context.Credoes.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.Credos == null)
            {
                return RedirectToAction("Index", "Credo");
            }

            else
            {
                credos = model.Credos;
                foreach (var credo in credos)
                {
                    _context.Entry(credo).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                model.Credos = credos.ToList();
                return View(model);
            }
        }
    }
}