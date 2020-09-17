using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Systematycznosc.Migrations;
using Systematycznosc.Models;
using Systematycznosc.ViewModels;

namespace Systematycznosc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SystematycznoscContext _context;
        public HomeController() { _context = new SystematycznoscContext(); }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            HomeViewModelWrapper wrapper = new HomeViewModelWrapper();

            if (userProfile != null)
            {
                UserProfileViewModel UserProfile = new UserProfileViewModel(userProfile);
                wrapper.UserProfileViewModel = UserProfile;

                var credos = _context.Credoes.Where(x => x.UserProfileId == userId);
                var morningQuestions = _context.MorningQuestions.Where(x => x.UserProfileId == userId);
                var eveningQuestions = _context.EveningQuestions.Where(x => x.UserProfileId == userId);
                var todoes = _context.Todoes.Where(x => x.UserProfileId == userId);
                var imporantEvents = _context.ImportantEvents.Where(x => x.UserProfileId == userId);
                var familyBirthdays = _context.FamilyBirthdays.Where(x => x.UserProfileId == userId);
                var friendsBirthdays = _context.FriendsBirthdays.Where(x => x.UserProfileId == userId);
                var othersBirthdays = _context.OthersBirthdays.Where(x => x.UserProfileId == userId);
                var relationships = _context.Relationships.Where(x => x.UserProfileId == userId);
                var firstGoals = _context.FirstGoals.Where(x => x.UserProfileId == userId);
                var secondGoals = _context.SecondGoals.Where(x => x.UserProfileId == userId);
                var thirdGoals = _context.ThirdGoals.Where(x => x.UserProfileId == userId);
                var fourthGoals = _context.FourthGoals.Where(x => x.UserProfileId == userId);
                var fifthGoals = _context.FifthGoals.Where(x => x.UserProfileId == userId);
                var sixthGoals = _context.SixthGoals.Where(x => x.UserProfileId == userId);
                var seventhGoals = _context.SeventhGoals.Where(x => x.UserProfileId == userId);
                var eightGoals = _context.EighthGoals.Where(x => x.UserProfileId == userId);

                wrapper.CredoViewModel = new CredoViewModel(credos);
                wrapper.TodoViewModel = new TodoViewModel()
                {
                    Todoes = todoes.ToList(),
                    ImportantEvents = imporantEvents.ToList()
                };
                wrapper.RelationshipViewModel = new RelationshipViewModel(relationships);
                wrapper.QuestionViewModel = new QuestionViewModel()
                {
                    MorningQuestions = morningQuestions.ToList(),
                    EveningQuestions = eveningQuestions.ToList()
                };
                wrapper.BirthdayViewModel = new BirthdayViewModel()
                {
                    FamilyBirthdays = familyBirthdays.ToList(),
                    FriendsBirthdays = friendsBirthdays.ToList(),
                    OthersBirthdays = othersBirthdays.ToList()
                };
                wrapper.GoalViewModel = new GoalViewModel()
                {
                    FirstGoals = firstGoals.OrderBy(x => x.GoalDate).ToList(),
                    SecondGoals = secondGoals.OrderBy(x => x.GoalDate).ToList(),
                    ThirdGoals = thirdGoals.OrderBy(x => x.GoalDate).ToList(),
                    FourthGoals = fourthGoals.OrderBy(x => x.GoalDate).ToList(),
                    FifthGoals = fifthGoals.OrderBy(x => x.GoalDate).ToList(),
                    SixthGoals = sixthGoals.OrderBy(x => x.GoalDate).ToList(),
                    SeventhGoals = seventhGoals.OrderBy(x => x.GoalDate).ToList(),
                    EightGoals = eightGoals.OrderBy(x => x.GoalDate).ToList()
                };

                return View(wrapper);
            }

            return RedirectToAction("Manage", "Profile");
        }
    }
}