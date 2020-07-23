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
                foreach (var credo in credos.Where(x => x.CredoValue != null))
                {
                    _context.Entry(credo).State = EntityState.Modified;                                  
                }
                foreach (var credo in credos.Where(x => x.CredoValue == null))
                {
                    _context.Entry(credo).State = EntityState.Deleted;
                }
                _context.SaveChanges();
                model.Credos = credos.Where(x => x.CredoValue != null).ToList();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AddCredoPoprawne(int credoId, string credoValue)
        {
            var userId = User.Identity.GetUserId();
            UserProfile userProfile = _context.UserProfiles.Single(x => x.Id == userId);
            userProfile.Credos = _context.Credoes.Where(x => x.CredoId == credoId).ToList();


            if (userProfile.Credos == null)
            {
                var credo = new Credo
                {
                    CredoValue = credoValue,
                    UserProfileId = userId
                };
            }
            else
            {
                var credo = _context.Credoes.SingleOrDefault(x => x.CredoId == credoId);
                credo.CredoValue = credoValue;
            }
            _context.SaveChanges();

            ModelState.Clear();

            var credos = _context.Credoes.Where(x => x.UserProfileId == userId);
            CredoViewModel model = new CredoViewModel(credos);

            return View(model);
        }

        // TODO stworzyc nowa metode wywolywana na plusiku ktora ma cos takiego mniej wiecej:

    }
}