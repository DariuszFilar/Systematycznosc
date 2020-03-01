using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Systematycznosc.ViewModels;

namespace Systematycznosc.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private SystematycznoscContext _context;
        // GET: Profile
        public ProfileController() { _context = new SystematycznoscContext(); }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Manage()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            UserProfileViewModel model = new UserProfileViewModel(userProfile);
            return View(model);
        }
        [HttpPost]
        public ActionResult Manage(UserProfileViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            user.UserProfile = new UserProfile { Name = model.Name, Nickname = model.Nickname, Gender = model.Gender };

            _context.SaveChanges();
            return View(model);
        }
    }
}