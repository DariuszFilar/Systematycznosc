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
    public class BirthdayController : Controller
    {
        // GET: Birthday
        private readonly SystematycznoscContext _context;
        public BirthdayController() { _context = new SystematycznoscContext(); }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null)
            {
                BirthdayViewModel model = new BirthdayViewModel
                {
                    FamilyBirthdays = _context.FamilyBirthdays.Where(x => x.UserProfileId == userId).ToList(),
                    FriendsBirthdays = _context.FriendsBirthdays.Where(x => x.UserProfileId == userId).ToList(),
                    OthersBirthdays = _context.OthersBirthdays.Where(x => x.UserProfileId == userId).ToList()
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult Index(string familyBirthdayName, DateTime? familyBirthdayDate, string friendBirthdayName, DateTime? friendBirthdayDate, string otherBirthdayName, DateTime? otherBirthdayDate)
        {
            var userId = User.Identity.GetUserId();

            if (familyBirthdayName != null && familyBirthdayDate != null)
            {
                if (_context.FamilyBirthdays.Where(x => x.UserProfileId == userId).Count() < 12)
                {
                    var familyBirthday = new FamilyBirthday
                    {
                        FamilyBirthdayId = _context.FamilyBirthdays.Count() + 1,
                        FamilyBirthdayName = familyBirthdayName,
                        FamilyBirthdayDate = familyBirthdayDate,
                        UserProfileId = userId
                    };
                    _context.FamilyBirthdays.Add(familyBirthday);
                }
            }

            if (friendBirthdayName != null && friendBirthdayDate != null)
            {
                if (_context.FriendsBirthdays.Where(x => x.UserProfileId == userId).Count() < 12)
                {
                    var friendBirthday = new FriendBirthday
                    {
                        FriendBirthdayId = _context.FriendsBirthdays.Count() + 1,
                        FriendBirthdayName = friendBirthdayName,
                        FriendBirthdayDate = friendBirthdayDate,
                        UserProfileId = userId
                    };
                    _context.FriendsBirthdays.Add(friendBirthday);
                }
            }

            if (otherBirthdayName != null && otherBirthdayDate != null)
            {
                if (_context.OthersBirthdays.Where(x => x.UserProfileId == userId).Count() < 12)
                {
                    var otherBirthday = new OtherBirthday
                    {
                        OtherBirthdayId = _context.OthersBirthdays.Count() + 1,
                        OtherBirthdayName = otherBirthdayName,
                        OtherBirthdayDate = otherBirthdayDate,
                        UserProfileId = userId
                    };
                    _context.OthersBirthdays.Add(otherBirthday);
                }
            }

            _context.SaveChanges();
            ModelState.Clear();

            BirthdayViewModel model = new BirthdayViewModel
            {
                FamilyBirthdays = _context.FamilyBirthdays.Where(x => x.UserProfileId == userId).ToList(),
                FriendsBirthdays = _context.FriendsBirthdays.Where(x => x.UserProfileId == userId).ToList(),
                OthersBirthdays = _context.OthersBirthdays.Where(x => x.UserProfileId == userId).ToList()
            };
            
            if (familyBirthdayName != null && familyBirthdayDate != null)
                return PartialView("_FamilyBirthdayTable", model);
            if (friendBirthdayName != null && friendBirthdayDate != null)
                return PartialView("_FriendBirthdayTable", model);
            if (otherBirthdayName != null && otherBirthdayDate != null)
                return PartialView("_OtherBirthdayTable", model);
            else
                return View();
        }

        [HttpGet]
        public ActionResult FamilyBirthdayEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var familyBirthdays = _context.FamilyBirthdays.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                BirthdayViewModel model = new BirthdayViewModel(familyBirthdays);
                return View(model);
            }

            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult FamilyBirthdayEdit(BirthdayViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var familyBirthdays = _context.FamilyBirthdays.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.FamilyBirthdays == null)
            {
                return RedirectToAction("Index", "Todo");
            }

            else
            {
                familyBirthdays = model.FamilyBirthdays;
                foreach (var familyBirthday in familyBirthdays)
                {
                    if (familyBirthday.FamilyBirthdayName == null)
                    {
                        familyBirthday.FamilyBirthdayDate = null;
                    }
                    _context.Entry(familyBirthday).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult FriendBirthdayEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var friendsBirthdays = _context.FriendsBirthdays.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                BirthdayViewModel model = new BirthdayViewModel(friendsBirthdays);
                return View(model);
            }

            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult FriendBirthdayEdit(BirthdayViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var friendsBirthdays = _context.FriendsBirthdays.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.FriendsBirthdays == null)
            {
                return RedirectToAction("Index", "Todo");
            }

            else
            {
                friendsBirthdays = model.FriendsBirthdays;
                foreach (var friendBirthday in friendsBirthdays)
                {
                    if (friendBirthday.FriendBirthdayName == null)
                    {
                        friendBirthday.FriendBirthdayDate = null;
                    }
                    _context.Entry(friendBirthday).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult OtherBirthdayEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var othersBirthdays = _context.OthersBirthdays.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                BirthdayViewModel model = new BirthdayViewModel(othersBirthdays);
                return View(model);
            }

            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult OtherBirthdayEdit(BirthdayViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var othersBirthdays = _context.OthersBirthdays.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.OthersBirthdays == null)
            {
                return RedirectToAction("Index", "Todo");
            }

            else
            {
                othersBirthdays = model.OthersBirthdays;
                foreach (var otherBirthday in othersBirthdays)
                {
                    if (otherBirthday.OtherBirthdayName == null)
                    {
                        otherBirthday.OtherBirthdayDate = null;
                    }
                    _context.Entry(otherBirthday).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                return View(model);
            }
        }
    }
}