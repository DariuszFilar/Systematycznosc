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
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null)
            {
                UserProfileViewModel model = new UserProfileViewModel(userProfile);
                return View(model);
            }
            else
            {
                UserProfileViewModel model = new UserProfileViewModel();
                return View(model);
            }

        }
        [HttpPost]
        public ActionResult Manage(UserProfileViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user.UserProfile != null)
            {
                user.UserProfile.Name = model.Name;
                user.UserProfile.Nickname = model.Nickname;
                user.UserProfile.Gender = model.Gender;
                user.UserProfile.BirthDate = model.BirthDate;
                user.UserProfile.Photo = model.Photo;
            }
            else
            {
                user.UserProfile = new UserProfile { Id = model.Id, Name = model.Name, Nickname = model.Nickname, Gender = model.Gender, Photo=model.Photo};
            }
            _context.SaveChanges();
            return View(model);
        }
    }
}