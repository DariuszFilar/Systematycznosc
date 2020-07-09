using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            UserProfileViewModelWrapper wrapper = new UserProfileViewModelWrapper();

            if (userProfile != null)
            {
                UserProfileViewModel UserProfile = new UserProfileViewModel(userProfile);
                wrapper.UserProfileViewModel = UserProfile;

                var credos = _context.Credoes.Where(x => x.UserProfileId == userId);
                var morningQuestions = _context.MorningQuestions.FirstOrDefault(x => x.Id == userId);
                var eveningQuestions = _context.EveningQuestions.FirstOrDefault(x => x.Id == userId);
                var todo = _context.Todo.FirstOrDefault(x => x.Id == userId);
                var familyBirthday = _context.FamilyBirthday.FirstOrDefault(x => x.Id == userId);
                var friendsBirthday = _context.FriendsBirthday.FirstOrDefault(x => x.Id == userId);
                var othersBirthday = _context.OthersBirthday.FirstOrDefault(x => x.Id == userId);
                var relationship = _context.Relationship.FirstOrDefault(x => x.Id == userId);
                var goals = _context.Goals.FirstOrDefault(x => x.Id == userId);

                wrapper.CredoViewModel = new CredoViewModel(credos);
                wrapper.MorningQuestionsViewModel = new MorningQuestionsViewModel(morningQuestions);
                wrapper.EveningQuestionsViewModel = new EveningQuestionsViewModel(eveningQuestions);
                wrapper.TodoViewModel = new TodoViewModel(todo);
                wrapper.FamilyBirthdayViewModel = new FamilyBirthdayViewModel(familyBirthday);
                wrapper.FriendsBirthdayViewModel = new FriendsBirthdayViewModel(friendsBirthday);
                wrapper.OthersBirthdayViewModel = new OthersBirthdayViewModel(othersBirthday);
                wrapper.RelationshipViewModel = new RelationshipViewModel(relationship);
                wrapper.GoalsViewModel = new GoalsViewModel(goals);
                return View(wrapper);
            }

            return RedirectToAction("Manage", "Profile");
        }

        [HttpPost]
        public ActionResult Index(UserProfileViewModelWrapper model, string submitButton)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var goals = _context.Goals.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            switch (submitButton)
            {
                case "AGoal":
                    {
                        //Dla tych samych dat
                        if (goals.AGoalDate1 == null)
                        {
                            goals.AGoalDate1 = DateTime.Today;
                            goals.AGoal1 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate1 = goals.AGoalDate1;
                            model.GoalsViewModel.AGoal1 = goals.AGoal1;
                        }

                        if (goals.AGoalDate1 != null)
                        {
                            if (goals.AGoalDate1 == DateTime.Today)
                            {
                                goals.AGoalDate1 = DateTime.Today;
                                goals.AGoal1 = model.GoalsViewModel.AGoal1;
                                model.GoalsViewModel.AGoalDate1 = goals.AGoalDate1;
                                model.GoalsViewModel.AGoal1 = goals.AGoal1;
                            }
                        }
                        if (goals.AGoalDate2 != null && goals.AGoalDate2 == DateTime.Today)
                        {
                            goals.AGoalDate2 = DateTime.Today;
                            goals.AGoal2 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate2 = goals.AGoalDate2;
                            model.GoalsViewModel.AGoal2 = goals.AGoal2;
                        }
                        if (goals.AGoalDate3 != null && goals.AGoalDate3 == DateTime.Today)
                        {
                            goals.AGoalDate3 = DateTime.Today;
                            goals.AGoal3 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate3 = goals.AGoalDate3;
                            model.GoalsViewModel.AGoal3 = goals.AGoal3;
                        }
                        if (goals.AGoalDate4 != null && goals.AGoalDate4 == DateTime.Today)
                        {
                            goals.AGoalDate4 = DateTime.Today;
                            goals.AGoal4 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate4 = goals.AGoalDate4;
                            model.GoalsViewModel.AGoal4 = goals.AGoal4;
                        }
                        if (goals.AGoalDate5 != null && goals.AGoalDate5 == DateTime.Today)
                        {
                            goals.AGoalDate5 = DateTime.Today;
                            goals.AGoal5 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate5 = goals.AGoalDate5;
                            model.GoalsViewModel.AGoal5 = goals.AGoal5;
                        }
                        if (goals.AGoalDate6 != null && goals.AGoalDate6 == DateTime.Today)
                        {
                            goals.AGoalDate6 = DateTime.Today;
                            goals.AGoal6 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate6 = goals.AGoalDate6;
                            model.GoalsViewModel.AGoal6 = goals.AGoal6;
                        }
                        if (goals.AGoalDate7 != null && goals.AGoalDate7 == DateTime.Today)
                        {
                            goals.AGoalDate7 = DateTime.Today;
                            goals.AGoal7 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate7 = goals.AGoalDate7;
                            model.GoalsViewModel.AGoal7 = goals.AGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.AGoalDate1 != null && goals.AGoalDate2 == null && goals.AGoalDate1 != DateTime.Today)
                        {
                            goals.AGoalDate2 = DateTime.Today;
                            goals.AGoal2 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate2 = goals.AGoalDate2;
                            model.GoalsViewModel.AGoal2 = goals.AGoal2;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        else if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 == null && goals.AGoalDate2 != DateTime.Today)
                        {
                            goals.AGoalDate3 = DateTime.Today;
                            goals.AGoal3 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate3 = goals.AGoalDate3;
                            model.GoalsViewModel.AGoal3 = goals.AGoal3;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        else if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 != null && goals.AGoalDate4 == null && goals.AGoalDate3 != DateTime.Today)
                        {
                            goals.AGoalDate4 = DateTime.Today;
                            goals.AGoal4 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate4 = goals.AGoalDate4;
                            model.GoalsViewModel.AGoal4 = goals.AGoal4;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        else if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 != null && goals.AGoalDate4 != null && goals.AGoalDate5 == null && goals.AGoalDate4 != DateTime.Today)
                        {
                            goals.AGoalDate5 = DateTime.Today;
                            goals.AGoal5 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate5 = goals.AGoalDate5;
                            model.GoalsViewModel.AGoal5 = goals.AGoal5;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 != null && goals.AGoalDate4 != null && goals.AGoalDate5 != null && goals.AGoalDate6 == null && goals.AGoalDate5 != DateTime.Today)
                        {
                            goals.AGoalDate6 = DateTime.Today;
                            goals.AGoal6 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate6 = goals.AGoalDate6;
                            model.GoalsViewModel.AGoal6 = goals.AGoal6;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 != null && goals.AGoalDate4 != null && goals.AGoalDate5 != null && goals.AGoalDate6 != null &&
                           goals.AGoalDate7 == null && goals.AGoalDate6 != DateTime.Today)
                        {
                            goals.AGoalDate7 = DateTime.Today;
                            goals.AGoal7 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate7 = goals.AGoalDate7;
                            model.GoalsViewModel.AGoal7 = goals.AGoal7;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.AGoalDate7 != null && goals.AGoalDate7 != DateTime.Today)
                        {
                            goals.AGoal1 = goals.AGoal2;
                            goals.AGoalDate1 = goals.AGoalDate2;
                            goals.AGoal2 = goals.AGoal3;
                            goals.AGoalDate2 = goals.AGoalDate3;
                            goals.AGoal3 = goals.AGoal4;
                            goals.AGoalDate3 = goals.AGoalDate4;
                            goals.AGoal4 = goals.AGoal5;
                            goals.AGoalDate4 = goals.AGoalDate5;
                            goals.AGoal5 = goals.AGoal6;
                            goals.AGoalDate5 = goals.AGoalDate6;
                            goals.AGoal6 = goals.AGoal7;
                            goals.AGoalDate6 = goals.AGoalDate7;
                            goals.AGoal7 = model.GoalsViewModel.AGoal1;
                            goals.AGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_AGoalTable", model);
                        }

                        model.GoalsViewModel = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_AGoalTable", model.GoalsViewModel);
                    };
                //Dla B
                //Dla tych samych dat
                case "BGoal":
                    {
                        if (goals.BGoalDate1 == null)
                        {
                            goals.BGoalDate1 = DateTime.Today;
                            goals.BGoal1 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate1 = goals.BGoalDate1;
                            model.GoalsViewModel.BGoal1 = goals.BGoal1;
                        }
                        if (goals.BGoalDate1 != null && goals.BGoalDate1 == DateTime.Today)
                        {
                            goals.BGoalDate1 = DateTime.Today;
                            goals.BGoal1 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate1 = goals.BGoalDate1;
                            model.GoalsViewModel.BGoal1 = goals.BGoal1;
                        }
                        if (goals.BGoalDate2 != null && goals.BGoalDate2 == DateTime.Today)
                        {
                            goals.BGoalDate2 = DateTime.Today;
                            goals.BGoal2 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate2 = goals.BGoalDate2;
                            model.GoalsViewModel.BGoal2 = goals.BGoal2;
                        }
                        if (goals.BGoalDate3 != null && goals.BGoalDate3 == DateTime.Today)
                        {
                            goals.BGoalDate3 = DateTime.Today;
                            goals.BGoal3 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate3 = goals.BGoalDate3;
                            model.GoalsViewModel.BGoal3 = goals.BGoal3;
                        }
                        if (goals.BGoalDate4 != null && goals.BGoalDate4 == DateTime.Today)
                        {
                            goals.BGoalDate4 = DateTime.Today;
                            goals.BGoal4 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate4 = goals.BGoalDate4;
                            model.GoalsViewModel.BGoal4 = goals.BGoal4;
                        }
                        if (goals.BGoalDate5 != null && goals.BGoalDate5 == DateTime.Today)
                        {
                            goals.BGoalDate5 = DateTime.Today;
                            goals.BGoal5 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate5 = goals.BGoalDate5;
                            model.GoalsViewModel.BGoal5 = goals.BGoal5;
                        }
                        if (goals.BGoalDate6 != null && goals.BGoalDate6 == DateTime.Today)
                        {
                            goals.BGoalDate6 = DateTime.Today;
                            goals.BGoal6 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate6 = goals.BGoalDate6;
                            model.GoalsViewModel.BGoal6 = goals.BGoal6;
                        }
                        if (goals.BGoalDate7 != null && goals.BGoalDate7 == DateTime.Today)
                        {
                            goals.BGoalDate7 = DateTime.Today;
                            goals.BGoal7 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate7 = goals.BGoalDate7;
                            model.GoalsViewModel.BGoal7 = goals.BGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.BGoalDate1 != null && goals.BGoalDate2 == null && goals.BGoalDate1 != DateTime.Today)
                        {
                            goals.BGoalDate2 = DateTime.Today;
                            goals.BGoal2 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate2 = goals.BGoalDate2;
                            model.GoalsViewModel.BGoal2 = goals.BGoal2;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);

                        }
                        else if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 == null && goals.BGoalDate2 != DateTime.Today)
                        {
                            goals.BGoalDate3 = DateTime.Today;
                            goals.BGoal3 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate3 = goals.BGoalDate3;
                            model.GoalsViewModel.BGoal3 = goals.BGoal3;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        else if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 != null && goals.BGoalDate4 == null && goals.BGoalDate3 != DateTime.Today)
                        {
                            goals.BGoalDate4 = DateTime.Today;
                            goals.BGoal4 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate4 = goals.BGoalDate4;
                            model.GoalsViewModel.BGoal4 = goals.BGoal4;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        else if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 != null && goals.BGoalDate4 != null && goals.BGoalDate5 == null && goals.BGoalDate4 != DateTime.Today)
                        {
                            goals.BGoalDate5 = DateTime.Today;
                            goals.BGoal5 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate5 = goals.BGoalDate5;
                            model.GoalsViewModel.BGoal5 = goals.BGoal5;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 != null && goals.BGoalDate4 != null && goals.BGoalDate5 != null && goals.BGoalDate6 == null && goals.BGoalDate5 != DateTime.Today)
                        {
                            goals.BGoalDate6 = DateTime.Today;
                            goals.BGoal6 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate6 = goals.BGoalDate6;
                            model.GoalsViewModel.BGoal6 = goals.BGoal6;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 != null && goals.BGoalDate4 != null && goals.BGoalDate5 != null && goals.BGoalDate6 != null &&
                           goals.BGoalDate7 == null && goals.BGoalDate6 != DateTime.Today)
                        {
                            goals.BGoalDate7 = DateTime.Today;
                            goals.BGoal7 = model.GoalsViewModel.BGoal1;
                            model.GoalsViewModel.BGoalDate7 = goals.BGoalDate7;
                            model.GoalsViewModel.BGoal7 = goals.BGoal7;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.BGoalDate7 != null && goals.BGoalDate7 != DateTime.Today)
                        {
                            goals.BGoal1 = goals.BGoal2;
                            goals.BGoalDate1 = goals.BGoalDate2;
                            goals.BGoal2 = goals.BGoal3;
                            goals.BGoalDate2 = goals.BGoalDate3;
                            goals.BGoal3 = goals.BGoal4;
                            goals.BGoalDate3 = goals.BGoalDate4;
                            goals.BGoal4 = goals.BGoal5;
                            goals.BGoalDate4 = goals.BGoalDate5;
                            goals.BGoal5 = goals.BGoal6;
                            goals.BGoalDate5 = goals.BGoalDate6;
                            goals.BGoal6 = goals.BGoal7;
                            goals.BGoalDate6 = goals.BGoalDate7;
                            goals.BGoal7 = model.GoalsViewModel.BGoal1;
                            goals.BGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_BGoalTable", model);
                        }
                        model.GoalsViewModel = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_BGoalTable", model.GoalsViewModel);
                    };
                case "CGoal":
                    {
                        if (goals.CGoalDate1 == null)
                        {
                            goals.CGoalDate1 = DateTime.Today;
                            goals.CGoal1 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate1 = goals.CGoalDate1;
                            model.GoalsViewModel.CGoal1 = goals.CGoal1;
                        }
                        if (goals.CGoalDate1 != null && goals.CGoalDate1 == DateTime.Today)
                        {
                            goals.CGoalDate1 = DateTime.Today;
                            goals.CGoal1 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate1 = goals.CGoalDate1;
                            model.GoalsViewModel.CGoal1 = goals.CGoal1;
                        }
                        if (goals.CGoalDate2 != null && goals.CGoalDate2 == DateTime.Today)
                        {
                            goals.CGoalDate2 = DateTime.Today;
                            goals.CGoal2 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate2 = goals.CGoalDate2;
                            model.GoalsViewModel.CGoal2 = goals.CGoal2;
                        }
                        if (goals.CGoalDate3 != null && goals.CGoalDate3 == DateTime.Today)
                        {
                            goals.CGoalDate3 = DateTime.Today;
                            goals.CGoal3 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate3 = goals.CGoalDate3;
                            model.GoalsViewModel.CGoal3 = goals.CGoal3;
                        }
                        if (goals.CGoalDate4 != null && goals.CGoalDate4 == DateTime.Today)
                        {
                            goals.CGoalDate4 = DateTime.Today;
                            goals.CGoal4 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate4 = goals.CGoalDate4;
                            model.GoalsViewModel.CGoal4 = goals.CGoal4;
                        }
                        if (goals.CGoalDate5 != null && goals.CGoalDate5 == DateTime.Today)
                        {
                            goals.CGoalDate5 = DateTime.Today;
                            goals.CGoal5 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate5 = goals.CGoalDate5;
                            model.GoalsViewModel.CGoal5 = goals.CGoal5;
                        }
                        if (goals.CGoalDate6 != null && goals.CGoalDate6 == DateTime.Today)
                        {
                            goals.CGoalDate6 = DateTime.Today;
                            goals.CGoal6 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate6 = goals.CGoalDate6;
                            model.GoalsViewModel.CGoal6 = goals.CGoal6;
                        }
                        if (goals.CGoalDate7 != null && goals.CGoalDate7 == DateTime.Today)
                        {
                            goals.CGoalDate7 = DateTime.Today;
                            goals.CGoal7 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate7 = goals.CGoalDate7;
                            model.GoalsViewModel.CGoal7 = goals.CGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.CGoalDate1 != null && goals.CGoalDate2 == null && goals.CGoalDate1 != DateTime.Today)
                        {
                            goals.CGoalDate2 = DateTime.Today;
                            goals.CGoal2 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate2 = goals.CGoalDate2;
                            model.GoalsViewModel.CGoal2 = goals.CGoal2;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);

                        }
                        else if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 == null && goals.CGoalDate2 != DateTime.Today)
                        {
                            goals.CGoalDate3 = DateTime.Today;
                            goals.CGoal3 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate3 = goals.CGoalDate3;
                            model.GoalsViewModel.CGoal3 = goals.CGoal3;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        else if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 != null && goals.CGoalDate4 == null && goals.CGoalDate3 != DateTime.Today)
                        {
                            goals.CGoalDate4 = DateTime.Today;
                            goals.CGoal4 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate4 = goals.CGoalDate4;
                            model.GoalsViewModel.CGoal4 = goals.CGoal4;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        else if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 != null && goals.CGoalDate4 != null && goals.CGoalDate5 == null && goals.CGoalDate4 != DateTime.Today)
                        {
                            goals.CGoalDate5 = DateTime.Today;
                            goals.CGoal5 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate5 = goals.CGoalDate5;
                            model.GoalsViewModel.CGoal5 = goals.CGoal5;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 != null && goals.CGoalDate4 != null && goals.CGoalDate5 != null && goals.CGoalDate6 == null && goals.CGoalDate5 != DateTime.Today)
                        {
                            goals.CGoalDate6 = DateTime.Today;
                            goals.CGoal6 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate6 = goals.CGoalDate6;
                            model.GoalsViewModel.CGoal6 = goals.CGoal6;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 != null && goals.CGoalDate4 != null && goals.CGoalDate5 != null && goals.CGoalDate6 != null &&
                           goals.CGoalDate7 == null && goals.CGoalDate6 != DateTime.Today)
                        {
                            goals.CGoalDate7 = DateTime.Today;
                            goals.CGoal7 = model.GoalsViewModel.CGoal1;
                            model.GoalsViewModel.CGoalDate7 = goals.CGoalDate7;
                            model.GoalsViewModel.CGoal7 = goals.CGoal7;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.CGoalDate7 != null && goals.CGoalDate7 != DateTime.Today)
                        {
                            goals.CGoal1 = goals.CGoal2;
                            goals.CGoalDate1 = goals.CGoalDate2;
                            goals.CGoal2 = goals.CGoal3;
                            goals.CGoalDate2 = goals.CGoalDate3;
                            goals.CGoal3 = goals.CGoal4;
                            goals.CGoalDate3 = goals.CGoalDate4;
                            goals.CGoal4 = goals.CGoal5;
                            goals.CGoalDate4 = goals.CGoalDate5;
                            goals.CGoal5 = goals.CGoal6;
                            goals.CGoalDate5 = goals.CGoalDate6;
                            goals.CGoal6 = goals.CGoal7;
                            goals.CGoalDate6 = goals.CGoalDate7;
                            goals.CGoal7 = model.GoalsViewModel.CGoal1;
                            goals.CGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_CGoalTable", model);
                        }
                        model.GoalsViewModel = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_CGoalTable", model.GoalsViewModel);
                    };
                case "DGoal":
                    {
                        if (goals.DGoalDate1 == null)
                        {
                            goals.DGoalDate1 = DateTime.Today;
                            goals.DGoal1 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate1 = goals.DGoalDate1;
                            model.GoalsViewModel.DGoal1 = goals.DGoal1;
                        }
                        if (goals.DGoalDate1 != null && goals.DGoalDate1 == DateTime.Today)
                        {
                            goals.DGoalDate1 = DateTime.Today;
                            goals.DGoal1 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate1 = goals.DGoalDate1;
                            model.GoalsViewModel.DGoal1 = goals.DGoal1;
                        }
                        if (goals.DGoalDate2 != null && goals.DGoalDate2 == DateTime.Today)
                        {
                            goals.DGoalDate2 = DateTime.Today;
                            goals.DGoal2 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate2 = goals.DGoalDate2;
                            model.GoalsViewModel.DGoal2 = goals.DGoal2;
                        }
                        if (goals.DGoalDate3 != null && goals.DGoalDate3 == DateTime.Today)
                        {
                            goals.DGoalDate3 = DateTime.Today;
                            goals.DGoal3 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate3 = goals.DGoalDate3;
                            model.GoalsViewModel.DGoal3 = goals.DGoal3;
                        }
                        if (goals.DGoalDate4 != null && goals.DGoalDate4 == DateTime.Today)
                        {
                            goals.DGoalDate4 = DateTime.Today;
                            goals.DGoal4 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate4 = goals.DGoalDate4;
                            model.GoalsViewModel.DGoal4 = goals.DGoal4;
                        }
                        if (goals.DGoalDate5 != null && goals.DGoalDate5 == DateTime.Today)
                        {
                            goals.DGoalDate5 = DateTime.Today;
                            goals.DGoal5 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate5 = goals.DGoalDate5;
                            model.GoalsViewModel.DGoal5 = goals.DGoal5;
                        }
                        if (goals.DGoalDate6 != null && goals.DGoalDate6 == DateTime.Today)
                        {
                            goals.DGoalDate6 = DateTime.Today;
                            goals.DGoal6 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate6 = goals.DGoalDate6;
                            model.GoalsViewModel.DGoal6 = goals.DGoal6;
                        }
                        if (goals.DGoalDate7 != null && goals.DGoalDate7 == DateTime.Today)
                        {
                            goals.DGoalDate7 = DateTime.Today;
                            goals.DGoal7 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate7 = goals.DGoalDate7;
                            model.GoalsViewModel.DGoal7 = goals.DGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.DGoalDate1 != null && goals.DGoalDate2 == null && goals.DGoalDate1 != DateTime.Today)
                        {
                            goals.DGoalDate2 = DateTime.Today;
                            goals.DGoal2 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate2 = goals.DGoalDate2;
                            model.GoalsViewModel.DGoal2 = goals.DGoal2;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);

                        }
                        else if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 == null && goals.DGoalDate2 != DateTime.Today)
                        {
                            goals.DGoalDate3 = DateTime.Today;
                            goals.DGoal3 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate3 = goals.DGoalDate3;
                            model.GoalsViewModel.DGoal3 = goals.DGoal3;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        else if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 != null && goals.DGoalDate4 == null && goals.DGoalDate3 != DateTime.Today)
                        {
                            goals.DGoalDate4 = DateTime.Today;
                            goals.DGoal4 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate4 = goals.DGoalDate4;
                            model.GoalsViewModel.DGoal4 = goals.DGoal4;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        else if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 != null && goals.DGoalDate4 != null && goals.DGoalDate5 == null && goals.DGoalDate4 != DateTime.Today)
                        {
                            goals.DGoalDate5 = DateTime.Today;
                            goals.DGoal5 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate5 = goals.DGoalDate5;
                            model.GoalsViewModel.DGoal5 = goals.DGoal5;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 != null && goals.DGoalDate4 != null && goals.DGoalDate5 != null && goals.DGoalDate6 == null && goals.DGoalDate5 != DateTime.Today)
                        {
                            goals.DGoalDate6 = DateTime.Today;
                            goals.DGoal6 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate6 = goals.DGoalDate6;
                            model.GoalsViewModel.DGoal6 = goals.DGoal6;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 != null && goals.DGoalDate4 != null && goals.DGoalDate5 != null && goals.DGoalDate6 != null &&
                           goals.DGoalDate7 == null && goals.DGoalDate6 != DateTime.Today)
                        {
                            goals.DGoalDate7 = DateTime.Today;
                            goals.DGoal7 = model.GoalsViewModel.DGoal1;
                            model.GoalsViewModel.DGoalDate7 = goals.DGoalDate7;
                            model.GoalsViewModel.DGoal7 = goals.DGoal7;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.DGoalDate7 != null && goals.DGoalDate7 != DateTime.Today)
                        {
                            goals.DGoal1 = goals.DGoal2;
                            goals.DGoalDate1 = goals.DGoalDate2;
                            goals.DGoal2 = goals.DGoal3;
                            goals.DGoalDate2 = goals.DGoalDate3;
                            goals.DGoal3 = goals.DGoal4;
                            goals.DGoalDate3 = goals.DGoalDate4;
                            goals.DGoal4 = goals.DGoal5;
                            goals.DGoalDate4 = goals.DGoalDate5;
                            goals.DGoal5 = goals.DGoal6;
                            goals.DGoalDate5 = goals.DGoalDate6;
                            goals.DGoal6 = goals.DGoal7;
                            goals.DGoalDate6 = goals.DGoalDate7;
                            goals.DGoal7 = model.GoalsViewModel.DGoal1;
                            goals.DGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_DGoalTable", model);
                        }
                        model.GoalsViewModel = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_DGoalTable", model.GoalsViewModel);
                    };
                case "EGoal":
                    {
                        if (goals.EGoalDate1 == null)
                        {
                            goals.EGoalDate1 = DateTime.Today;
                            goals.EGoal1 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate1 = goals.EGoalDate1;
                            model.GoalsViewModel.EGoal1 = goals.EGoal1;
                        }
                        if (goals.EGoalDate1 != null && goals.EGoalDate1 == DateTime.Today)
                        {
                            goals.EGoalDate1 = DateTime.Today;
                            goals.EGoal1 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate1 = goals.EGoalDate1;
                            model.GoalsViewModel.EGoal1 = goals.EGoal1;
                        }
                        if (goals.EGoalDate2 != null && goals.EGoalDate2 == DateTime.Today)
                        {
                            goals.EGoalDate2 = DateTime.Today;
                            goals.EGoal2 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate2 = goals.EGoalDate2;
                            model.GoalsViewModel.EGoal2 = goals.EGoal2;
                        }
                        if (goals.EGoalDate3 != null && goals.EGoalDate3 == DateTime.Today)
                        {
                            goals.EGoalDate3 = DateTime.Today;
                            goals.EGoal3 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate3 = goals.EGoalDate3;
                            model.GoalsViewModel.EGoal3 = goals.EGoal3;
                        }
                        if (goals.EGoalDate4 != null && goals.EGoalDate4 == DateTime.Today)
                        {
                            goals.EGoalDate4 = DateTime.Today;
                            goals.EGoal4 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate4 = goals.EGoalDate4;
                            model.GoalsViewModel.EGoal4 = goals.EGoal4;
                        }
                        if (goals.EGoalDate5 != null && goals.EGoalDate5 == DateTime.Today)
                        {
                            goals.EGoalDate5 = DateTime.Today;
                            goals.EGoal5 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate5 = goals.EGoalDate5;
                            model.GoalsViewModel.EGoal5 = goals.EGoal5;
                        }
                        if (goals.EGoalDate6 != null && goals.EGoalDate6 == DateTime.Today)
                        {
                            goals.EGoalDate6 = DateTime.Today;
                            goals.EGoal6 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate6 = goals.EGoalDate6;
                            model.GoalsViewModel.EGoal6 = goals.EGoal6;
                        }
                        if (goals.EGoalDate7 != null && goals.EGoalDate7 == DateTime.Today)
                        {
                            goals.EGoalDate7 = DateTime.Today;
                            goals.EGoal7 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate7 = goals.EGoalDate7;
                            model.GoalsViewModel.EGoal7 = goals.EGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.EGoalDate1 != null && goals.EGoalDate2 == null && goals.EGoalDate1 != DateTime.Today)
                        {
                            goals.EGoalDate2 = DateTime.Today;
                            goals.EGoal2 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate2 = goals.EGoalDate2;
                            model.GoalsViewModel.EGoal2 = goals.EGoal2;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);

                        }
                        else if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 == null && goals.EGoalDate2 != DateTime.Today)
                        {
                            goals.EGoalDate3 = DateTime.Today;
                            goals.EGoal3 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate3 = goals.EGoalDate3;
                            model.GoalsViewModel.EGoal3 = goals.EGoal3;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        else if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 != null && goals.EGoalDate4 == null && goals.EGoalDate3 != DateTime.Today)
                        {
                            goals.EGoalDate4 = DateTime.Today;
                            goals.EGoal4 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate4 = goals.EGoalDate4;
                            model.GoalsViewModel.EGoal4 = goals.EGoal4;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        else if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 != null && goals.EGoalDate4 != null && goals.EGoalDate5 == null && goals.EGoalDate4 != DateTime.Today)
                        {
                            goals.EGoalDate5 = DateTime.Today;
                            goals.EGoal5 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate5 = goals.EGoalDate5;
                            model.GoalsViewModel.EGoal5 = goals.EGoal5;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 != null && goals.EGoalDate4 != null && goals.EGoalDate5 != null && goals.EGoalDate6 == null && goals.EGoalDate5 != DateTime.Today)
                        {
                            goals.EGoalDate6 = DateTime.Today;
                            goals.EGoal6 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate6 = goals.EGoalDate6;
                            model.GoalsViewModel.EGoal6 = goals.EGoal6;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 != null && goals.EGoalDate4 != null && goals.EGoalDate5 != null && goals.EGoalDate6 != null &&
                           goals.EGoalDate7 == null && goals.EGoalDate6 != DateTime.Today)
                        {
                            goals.EGoalDate7 = DateTime.Today;
                            goals.EGoal7 = model.GoalsViewModel.EGoal1;
                            model.GoalsViewModel.EGoalDate7 = goals.EGoalDate7;
                            model.GoalsViewModel.EGoal7 = goals.EGoal7;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.EGoalDate7 != null && goals.EGoalDate7 != DateTime.Today)
                        {
                            goals.EGoal1 = goals.EGoal2;
                            goals.EGoalDate1 = goals.EGoalDate2;
                            goals.EGoal2 = goals.EGoal3;
                            goals.EGoalDate2 = goals.EGoalDate3;
                            goals.EGoal3 = goals.EGoal4;
                            goals.EGoalDate3 = goals.EGoalDate4;
                            goals.EGoal4 = goals.EGoal5;
                            goals.EGoalDate4 = goals.EGoalDate5;
                            goals.EGoal5 = goals.EGoal6;
                            goals.EGoalDate5 = goals.EGoalDate6;
                            goals.EGoal6 = goals.EGoal7;
                            goals.EGoalDate6 = goals.EGoalDate7;
                            goals.EGoal7 = model.GoalsViewModel.EGoal1;
                            goals.EGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_EGoalTable", model);
                        }
                        model.GoalsViewModel = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_EGoalTable", model.GoalsViewModel);
                    };
                case "FGoal":
                    {
                        if (goals.FGoalDate1 == null)
                        {
                            goals.FGoalDate1 = DateTime.Today;
                            goals.FGoal1 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate1 = goals.FGoalDate1;
                            model.GoalsViewModel.FGoal1 = goals.FGoal1;
                        }
                        if (goals.FGoalDate1 != null && goals.FGoalDate1 == DateTime.Today)
                        {
                            goals.FGoalDate1 = DateTime.Today;
                            goals.FGoal1 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate1 = goals.FGoalDate1;
                            model.GoalsViewModel.FGoal1 = goals.FGoal1;
                        }
                        if (goals.FGoalDate2 != null && goals.FGoalDate2 == DateTime.Today)
                        {
                            goals.FGoalDate2 = DateTime.Today;
                            goals.FGoal2 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate2 = goals.FGoalDate2;
                            model.GoalsViewModel.FGoal2 = goals.FGoal2;
                        }
                        if (goals.FGoalDate3 != null && goals.FGoalDate3 == DateTime.Today)
                        {
                            goals.FGoalDate3 = DateTime.Today;
                            goals.FGoal3 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate3 = goals.FGoalDate3;
                            model.GoalsViewModel.FGoal3 = goals.FGoal3;
                        }
                        if (goals.FGoalDate4 != null && goals.FGoalDate4 == DateTime.Today)
                        {
                            goals.FGoalDate4 = DateTime.Today;
                            goals.FGoal4 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate4 = goals.FGoalDate4;
                            model.GoalsViewModel.FGoal4 = goals.FGoal4;
                        }
                        if (goals.FGoalDate5 != null && goals.FGoalDate5 == DateTime.Today)
                        {
                            goals.FGoalDate5 = DateTime.Today;
                            goals.FGoal5 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate5 = goals.FGoalDate5;
                            model.GoalsViewModel.FGoal5 = goals.FGoal5;
                        }
                        if (goals.FGoalDate6 != null && goals.FGoalDate6 == DateTime.Today)
                        {
                            goals.FGoalDate6 = DateTime.Today;
                            goals.FGoal6 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate6 = goals.FGoalDate6;
                            model.GoalsViewModel.FGoal6 = goals.FGoal6;
                        }
                        if (goals.FGoalDate7 != null && goals.FGoalDate7 == DateTime.Today)
                        {
                            goals.FGoalDate7 = DateTime.Today;
                            goals.FGoal7 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate7 = goals.FGoalDate7;
                            model.GoalsViewModel.FGoal7 = goals.FGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.FGoalDate1 != null && goals.FGoalDate2 == null && goals.FGoalDate1 != DateTime.Today)
                        {
                            goals.FGoalDate2 = DateTime.Today;
                            goals.FGoal2 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate2 = goals.FGoalDate2;
                            model.GoalsViewModel.FGoal2 = goals.FGoal2;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);

                        }
                        else if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 == null && goals.FGoalDate2 != DateTime.Today)
                        {
                            goals.FGoalDate3 = DateTime.Today;
                            goals.FGoal3 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate3 = goals.FGoalDate3;
                            model.GoalsViewModel.FGoal3 = goals.FGoal3;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        else if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 != null && goals.FGoalDate4 == null && goals.FGoalDate3 != DateTime.Today)
                        {
                            goals.FGoalDate4 = DateTime.Today;
                            goals.FGoal4 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate4 = goals.FGoalDate4;
                            model.GoalsViewModel.FGoal4 = goals.FGoal4;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        else if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 != null && goals.FGoalDate4 != null && goals.FGoalDate5 == null && goals.FGoalDate4 != DateTime.Today)
                        {
                            goals.FGoalDate5 = DateTime.Today;
                            goals.FGoal5 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate5 = goals.FGoalDate5;
                            model.GoalsViewModel.FGoal5 = goals.FGoal5;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 != null && goals.FGoalDate4 != null && goals.FGoalDate5 != null && goals.FGoalDate6 == null && goals.FGoalDate5 != DateTime.Today)
                        {
                            goals.FGoalDate6 = DateTime.Today;
                            goals.FGoal6 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate6 = goals.FGoalDate6;
                            model.GoalsViewModel.FGoal6 = goals.FGoal6;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 != null && goals.FGoalDate4 != null && goals.FGoalDate5 != null && goals.FGoalDate6 != null &&
                           goals.FGoalDate7 == null && goals.FGoalDate6 != DateTime.Today)
                        {
                            goals.FGoalDate7 = DateTime.Today;
                            goals.FGoal7 = model.GoalsViewModel.FGoal1;
                            model.GoalsViewModel.FGoalDate7 = goals.FGoalDate7;
                            model.GoalsViewModel.FGoal7 = goals.FGoal7;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.FGoalDate7 != null && goals.FGoalDate7 != DateTime.Today)
                        {
                            goals.FGoal1 = goals.FGoal2;
                            goals.FGoalDate1 = goals.FGoalDate2;
                            goals.FGoal2 = goals.FGoal3;
                            goals.FGoalDate2 = goals.FGoalDate3;
                            goals.FGoal3 = goals.FGoal4;
                            goals.FGoalDate3 = goals.FGoalDate4;
                            goals.FGoal4 = goals.FGoal5;
                            goals.FGoalDate4 = goals.FGoalDate5;
                            goals.FGoal5 = goals.FGoal6;
                            goals.FGoalDate5 = goals.FGoalDate6;
                            goals.FGoal6 = goals.FGoal7;
                            goals.FGoalDate6 = goals.FGoalDate7;
                            goals.FGoal7 = model.GoalsViewModel.FGoal1;
                            goals.FGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_FGoalTable", model);
                        }
                        model.GoalsViewModel = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_FGoalTable", model.GoalsViewModel);
                    };
                case "GGoal":
                    {
                        if (goals.GGoalDate1 == null)
                        {
                            goals.GGoalDate1 = DateTime.Today;
                            goals.GGoal1 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate1 = goals.GGoalDate1;
                            model.GoalsViewModel.GGoal1 = goals.GGoal1;
                        }
                        if (goals.GGoalDate1 != null && goals.GGoalDate1 == DateTime.Today)
                        {
                            goals.GGoalDate1 = DateTime.Today;
                            goals.GGoal1 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate1 = goals.GGoalDate1;
                            model.GoalsViewModel.GGoal1 = goals.GGoal1;
                        }
                        if (goals.GGoalDate2 != null && goals.GGoalDate2 == DateTime.Today)
                        {
                            goals.GGoalDate2 = DateTime.Today;
                            goals.GGoal2 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate2 = goals.GGoalDate2;
                            model.GoalsViewModel.GGoal2 = goals.GGoal2;
                        }
                        if (goals.GGoalDate3 != null && goals.GGoalDate3 == DateTime.Today)
                        {
                            goals.GGoalDate3 = DateTime.Today;
                            goals.GGoal3 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate3 = goals.GGoalDate3;
                            model.GoalsViewModel.GGoal3 = goals.GGoal3;
                        }
                        if (goals.GGoalDate4 != null && goals.GGoalDate4 == DateTime.Today)
                        {
                            goals.GGoalDate4 = DateTime.Today;
                            goals.GGoal4 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate4 = goals.GGoalDate4;
                            model.GoalsViewModel.GGoal4 = goals.GGoal4;
                        }
                        if (goals.GGoalDate5 != null && goals.GGoalDate5 == DateTime.Today)
                        {
                            goals.GGoalDate5 = DateTime.Today;
                            goals.GGoal5 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate5 = goals.GGoalDate5;
                            model.GoalsViewModel.GGoal5 = goals.GGoal5;
                        }
                        if (goals.GGoalDate6 != null && goals.GGoalDate6 == DateTime.Today)
                        {
                            goals.GGoalDate6 = DateTime.Today;
                            goals.GGoal6 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate6 = goals.GGoalDate6;
                            model.GoalsViewModel.GGoal6 = goals.GGoal6;
                        }
                        if (goals.GGoalDate7 != null && goals.GGoalDate7 == DateTime.Today)
                        {
                            goals.GGoalDate7 = DateTime.Today;
                            goals.GGoal7 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate7 = goals.GGoalDate7;
                            model.GoalsViewModel.GGoal7 = goals.GGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.GGoalDate1 != null && goals.GGoalDate2 == null && goals.GGoalDate1 != DateTime.Today)
                        {
                            goals.GGoalDate2 = DateTime.Today;
                            goals.GGoal2 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate2 = goals.GGoalDate2;
                            model.GoalsViewModel.GGoal2 = goals.GGoal2;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);

                        }
                        else if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 == null && goals.GGoalDate2 != DateTime.Today)
                        {
                            goals.GGoalDate3 = DateTime.Today;
                            goals.GGoal3 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate3 = goals.GGoalDate3;
                            model.GoalsViewModel.GGoal3 = goals.GGoal3;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        else if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 != null && goals.GGoalDate4 == null && goals.GGoalDate3 != DateTime.Today)
                        {
                            goals.GGoalDate4 = DateTime.Today;
                            goals.GGoal4 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate4 = goals.GGoalDate4;
                            model.GoalsViewModel.GGoal4 = goals.GGoal4;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        else if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 != null && goals.GGoalDate4 != null && goals.GGoalDate5 == null && goals.GGoalDate4 != DateTime.Today)
                        {
                            goals.GGoalDate5 = DateTime.Today;
                            goals.GGoal5 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate5 = goals.GGoalDate5;
                            model.GoalsViewModel.GGoal5 = goals.GGoal5;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 != null && goals.GGoalDate4 != null && goals.GGoalDate5 != null && goals.GGoalDate6 == null && goals.GGoalDate5 != DateTime.Today)
                        {
                            goals.GGoalDate6 = DateTime.Today;
                            goals.GGoal6 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate6 = goals.GGoalDate6;
                            model.GoalsViewModel.GGoal6 = goals.GGoal6;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 != null && goals.GGoalDate4 != null && goals.GGoalDate5 != null && goals.GGoalDate6 != null &&
                           goals.GGoalDate7 == null && goals.GGoalDate6 != DateTime.Today)
                        {
                            goals.GGoalDate7 = DateTime.Today;
                            goals.GGoal7 = model.GoalsViewModel.GGoal1;
                            model.GoalsViewModel.GGoalDate7 = goals.GGoalDate7;
                            model.GoalsViewModel.GGoal7 = goals.GGoal7;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.GGoalDate7 != null && goals.GGoalDate7 != DateTime.Today)
                        {
                            goals.GGoal1 = goals.GGoal2;
                            goals.GGoalDate1 = goals.GGoalDate2;
                            goals.GGoal2 = goals.GGoal3;
                            goals.GGoalDate2 = goals.GGoalDate3;
                            goals.GGoal3 = goals.GGoal4;
                            goals.GGoalDate3 = goals.GGoalDate4;
                            goals.GGoal4 = goals.GGoal5;
                            goals.GGoalDate4 = goals.GGoalDate5;
                            goals.GGoal5 = goals.GGoal6;
                            goals.GGoalDate5 = goals.GGoalDate6;
                            goals.GGoal6 = goals.GGoal7;
                            goals.GGoalDate6 = goals.GGoalDate7;
                            goals.GGoal7 = model.GoalsViewModel.GGoal1;
                            goals.GGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_GGoalTable", model);
                        }
                        model.GoalsViewModel = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_GGoalTable", model.GoalsViewModel);
                    };
                case "HGoal":
                    {
                        if (goals.HGoalDate1 == null)
                        {
                            goals.HGoalDate1 = DateTime.Today;
                            goals.HGoal1 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate1 = goals.HGoalDate1;
                            model.GoalsViewModel.HGoal1 = goals.HGoal1;
                        }
                        if (goals.HGoalDate1 != null && goals.HGoalDate1 == DateTime.Today)
                        {
                            goals.HGoalDate1 = DateTime.Today;
                            goals.HGoal1 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate1 = goals.HGoalDate1;
                            model.GoalsViewModel.HGoal1 = goals.HGoal1;
                        }
                        if (goals.HGoalDate2 != null && goals.HGoalDate2 == DateTime.Today)
                        {
                            goals.HGoalDate2 = DateTime.Today;
                            goals.HGoal2 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate2 = goals.HGoalDate2;
                            model.GoalsViewModel.HGoal2 = goals.HGoal2;
                        }
                        if (goals.HGoalDate3 != null && goals.HGoalDate3 == DateTime.Today)
                        {
                            goals.HGoalDate3 = DateTime.Today;
                            goals.HGoal3 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate3 = goals.HGoalDate3;
                            model.GoalsViewModel.HGoal3 = goals.HGoal3;
                        }
                        if (goals.HGoalDate4 != null && goals.HGoalDate4 == DateTime.Today)
                        {
                            goals.HGoalDate4 = DateTime.Today;
                            goals.HGoal4 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate4 = goals.HGoalDate4;
                            model.GoalsViewModel.HGoal4 = goals.HGoal4;
                        }
                        if (goals.HGoalDate5 != null && goals.HGoalDate5 == DateTime.Today)
                        {
                            goals.HGoalDate5 = DateTime.Today;
                            goals.HGoal5 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate5 = goals.HGoalDate5;
                            model.GoalsViewModel.HGoal5 = goals.HGoal5;
                        }
                        if (goals.HGoalDate6 != null && goals.HGoalDate6 == DateTime.Today)
                        {
                            goals.HGoalDate6 = DateTime.Today;
                            goals.HGoal6 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate6 = goals.HGoalDate6;
                            model.GoalsViewModel.HGoal6 = goals.HGoal6;
                        }
                        if (goals.HGoalDate7 != null && goals.HGoalDate7 == DateTime.Today)
                        {
                            goals.HGoalDate7 = DateTime.Today;
                            goals.HGoal7 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate7 = goals.HGoalDate7;
                            model.GoalsViewModel.HGoal7 = goals.HGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.HGoalDate1 != null && goals.HGoalDate2 == null && goals.HGoalDate1 != DateTime.Today)
                        {
                            goals.HGoalDate2 = DateTime.Today;
                            goals.HGoal2 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate2 = goals.HGoalDate2;
                            model.GoalsViewModel.HGoal2 = goals.HGoal2;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);

                        }
                        else if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 == null && goals.HGoalDate2 != DateTime.Today)
                        {
                            goals.HGoalDate3 = DateTime.Today;
                            goals.HGoal3 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate3 = goals.HGoalDate3;
                            model.GoalsViewModel.HGoal3 = goals.HGoal3;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        else if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 != null && goals.HGoalDate4 == null && goals.HGoalDate3 != DateTime.Today)
                        {
                            goals.HGoalDate4 = DateTime.Today;
                            goals.HGoal4 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate4 = goals.HGoalDate4;
                            model.GoalsViewModel.HGoal4 = goals.HGoal4;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        else if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 != null && goals.HGoalDate4 != null && goals.HGoalDate5 == null && goals.HGoalDate4 != DateTime.Today)
                        {
                            goals.HGoalDate5 = DateTime.Today;
                            goals.HGoal5 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate5 = goals.HGoalDate5;
                            model.GoalsViewModel.HGoal5 = goals.HGoal5;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 != null && goals.HGoalDate4 != null && goals.HGoalDate5 != null && goals.HGoalDate6 == null && goals.HGoalDate5 != DateTime.Today)
                        {
                            goals.HGoalDate6 = DateTime.Today;
                            goals.HGoal6 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate6 = goals.HGoalDate6;
                            model.GoalsViewModel.HGoal6 = goals.HGoal6;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 != null && goals.HGoalDate4 != null && goals.HGoalDate5 != null && goals.HGoalDate6 != null &&
                           goals.HGoalDate7 == null && goals.HGoalDate6 != DateTime.Today)
                        {
                            goals.HGoalDate7 = DateTime.Today;
                            goals.HGoal7 = model.GoalsViewModel.HGoal1;
                            model.GoalsViewModel.HGoalDate7 = goals.HGoalDate7;
                            model.GoalsViewModel.HGoal7 = goals.HGoal7;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.HGoalDate7 != null && goals.HGoalDate7 != DateTime.Today)
                        {
                            goals.HGoal1 = goals.HGoal2;
                            goals.HGoalDate1 = goals.HGoalDate2;
                            goals.HGoal2 = goals.HGoal3;
                            goals.HGoalDate2 = goals.HGoalDate3;
                            goals.HGoal3 = goals.HGoal4;
                            goals.HGoalDate3 = goals.HGoalDate4;
                            goals.HGoal4 = goals.HGoal5;
                            goals.HGoalDate4 = goals.HGoalDate5;
                            goals.HGoal5 = goals.HGoal6;
                            goals.HGoalDate5 = goals.HGoalDate6;
                            goals.HGoal6 = goals.HGoal7;
                            goals.HGoalDate6 = goals.HGoalDate7;
                            goals.HGoal7 = model.GoalsViewModel.HGoal1;
                            goals.HGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_HGoalTable", model);
                        }
                        model.GoalsViewModel = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_HGoalTable", model.GoalsViewModel);
                    };
                default:
                    return PartialView("_BGoalTable", model);
            }
        }


        public ActionResult Credo()
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
            //var credos = _context.

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
        public ActionResult AddCredo(string credoValue)//credo value podane od uzytkownika z textboxa
        {
            var userId = User.Identity.GetUserId();
            var credo = new Credo
            {
                UserProfileId = userId,
                CredoValue = credoValue
            };
            // to ponizej w try catch
            UserProfile userProfile = _context.UserProfiles.Single(x => x.Id == userId);

            if (userProfile.Credos == null)
                userProfile.Credos = new List<Credo>();

            userProfile.Credos.Add(credo);

            return View();
        }


        [HttpPost]
        public ActionResult CredoEdit(string credoId)
        {
            var userId = User.Identity.GetUserId();
            //var credo = _context.Credoes.Where(x => x.UserProfileId == credoId);

            //if (credo == null)
            //    return View();

            UserProfile userProfile = _context.UserProfiles.Single(x => x.Id == userId);

            if (userProfile.Credos == null)
                userProfile.Credos = new List<Credo>();

            //userProfile.Credos

            return View();
        }

        // TODO stworzyc nowa metode wywolywana na plusiku ktora ma cos takiego mniej wiecej:


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
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var morningQuestions = _context.MorningQuestions.FirstOrDefault(x => x.Id == userId);
            var eveningQuestions = _context.EveningQuestions.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null && morningQuestions != null && eveningQuestions != null)
            {
                QuestionsViewModelWrapper wrapper = new QuestionsViewModelWrapper();
                MorningQuestionsViewModel MorningQuestions = new MorningQuestionsViewModel(morningQuestions);
                EveningQuestionsViewModel EveningQuestions = new EveningQuestionsViewModel(eveningQuestions);
                wrapper.MorningQuestionsViewModel = MorningQuestions;
                wrapper.EveningQuestionsViewModel = EveningQuestions;
                return View(wrapper);
            }

            if (userProfile != null && morningQuestions != null && eveningQuestions == null)
            {
                QuestionsViewModelWrapper wrapper = new QuestionsViewModelWrapper();
                MorningQuestionsViewModel MorningQuestions = new MorningQuestionsViewModel(morningQuestions);
                wrapper.MorningQuestionsViewModel = MorningQuestions;
                wrapper.EveningQuestionsViewModel = new EveningQuestionsViewModel();
                return View(wrapper);
            }
            else if (userProfile != null && eveningQuestions != null && morningQuestions == null)
            {
                QuestionsViewModelWrapper wrapper = new QuestionsViewModelWrapper();
                EveningQuestionsViewModel EveningQuestions = new EveningQuestionsViewModel(eveningQuestions);
                wrapper.EveningQuestionsViewModel = EveningQuestions;
                wrapper.MorningQuestionsViewModel = new MorningQuestionsViewModel();
                return View(wrapper);
            }
            else if (userProfile != null && eveningQuestions == null && morningQuestions == null)
            {
                QuestionsViewModelWrapper wrapper = new QuestionsViewModelWrapper
                {
                    MorningQuestionsViewModel = new MorningQuestionsViewModel(),
                    EveningQuestionsViewModel = new EveningQuestionsViewModel()
                };
                return View(wrapper);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }
        [HttpGet]
        public ActionResult MorningQuestionsEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var morningQuestions = _context.MorningQuestions.FirstOrDefault(x => x.Id == userId);

            if (morningQuestions != null)
            {
                MorningQuestionsViewModel model = new MorningQuestionsViewModel(morningQuestions);
                return View(model);
            }
            else
            {
                MorningQuestionsViewModel model = new MorningQuestionsViewModel();
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult MorningQuestionsEdit(MorningQuestionsViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var morningQuestions = _context.MorningQuestions.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            if (morningQuestions != null)
            {
                morningQuestions.MorningQuestions1 = model.MorningQuestions1;
                morningQuestions.MorningQuestions2 = model.MorningQuestions2;
                morningQuestions.MorningQuestions3 = model.MorningQuestions3;
                morningQuestions.MorningQuestions4 = model.MorningQuestions4;
                morningQuestions.MorningQuestions5 = model.MorningQuestions5;
                morningQuestions.MorningQuestions6 = model.MorningQuestions6;
                morningQuestions.MorningQuestions7 = model.MorningQuestions7;
                morningQuestions.MorningQuestions8 = model.MorningQuestions8;
                morningQuestions.MorningQuestions9 = model.MorningQuestions9;
                morningQuestions.MorningQuestions10 = model.MorningQuestions10;
            }
            else
            {
                user.MorningQuestions = new MorningQuestions
                {
                    MorningQuestions1 = model.MorningQuestions1,
                    MorningQuestions2 = model.MorningQuestions2,
                    MorningQuestions3 = model.MorningQuestions3,
                    MorningQuestions4 = model.MorningQuestions4,
                    MorningQuestions5 = model.MorningQuestions5,
                    MorningQuestions6 = model.MorningQuestions6,
                    MorningQuestions7 = model.MorningQuestions7,
                    MorningQuestions8 = model.MorningQuestions8,
                    MorningQuestions9 = model.MorningQuestions9,
                    MorningQuestions10 = model.MorningQuestions10
                };
            }
            _context.SaveChanges();
            return View(model);
        }
        [HttpGet]
        public ActionResult EveningQuestionsEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var eveningQuestions = _context.EveningQuestions.FirstOrDefault(x => x.Id == userId);

            if (eveningQuestions != null)
            {
                EveningQuestionsViewModel model = new EveningQuestionsViewModel(eveningQuestions);
                return View(model);
            }
            else
            {
                EveningQuestionsViewModel model = new EveningQuestionsViewModel();
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EveningQuestionsEdit(EveningQuestionsViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var eveningQuestions = _context.EveningQuestions.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            if (eveningQuestions != null)
            {
                eveningQuestions.EveningQuestions1 = model.EveningQuestion1;
                eveningQuestions.EveningQuestions2 = model.EveningQuestion2;
                eveningQuestions.EveningQuestions3 = model.EveningQuestion3;
                eveningQuestions.EveningQuestions4 = model.EveningQuestion4;
                eveningQuestions.EveningQuestions5 = model.EveningQuestion5;
                eveningQuestions.EveningQuestions6 = model.EveningQuestion6;
                eveningQuestions.EveningQuestions7 = model.EveningQuestion7;
                eveningQuestions.EveningQuestions8 = model.EveningQuestion8;
                eveningQuestions.EveningQuestions9 = model.EveningQuestion9;
                eveningQuestions.EveningQuestions10 = model.EveningQuestion10;
            }
            else
            {
                user.EveningQuestions = new Models.EveningQuestions
                {
                    EveningQuestions1 = model.EveningQuestion1,
                    EveningQuestions2 = model.EveningQuestion2,
                    EveningQuestions3 = model.EveningQuestion3,
                    EveningQuestions4 = model.EveningQuestion4,
                    EveningQuestions5 = model.EveningQuestion5,
                    EveningQuestions6 = model.EveningQuestion6,
                    EveningQuestions7 = model.EveningQuestion7,
                    EveningQuestions8 = model.EveningQuestion8,
                    EveningQuestions9 = model.EveningQuestion9,
                    EveningQuestions10 = model.EveningQuestion10
                };
            }
            _context.SaveChanges();
            return View(model);
        }

        [HttpGet]
        public ActionResult Todo()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var todo = _context.Todo.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null && todo != null)
            {
                TodoViewModel model = new TodoViewModel(todo);
                return View(model);
            }
            else if (userProfile != null && todo == null)
            {
                TodoViewModel model = new TodoViewModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }
        [HttpGet]
        public ActionResult TodoEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var todo = _context.Todo.FirstOrDefault(x => x.Id == userId);

            if (todo != null)
            {
                TodoViewModel model = new TodoViewModel(todo);
                return View(model);
            }
            else
            {
                TodoViewModel model = new TodoViewModel();
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult TodoEdit(TodoViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var todo = _context.Todo.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            if (todo != null)
            {
                todo.Todo1 = model.Todo1;
                todo.Todo2 = model.Todo2;
                todo.Todo3 = model.Todo3;
                todo.Todo4 = model.Todo4;
                todo.Todo5 = model.Todo5;
                todo.Todo6 = model.Todo6;
                todo.Todo7 = model.Todo7;
                todo.Todo8 = model.Todo8;
                todo.Todo9 = model.Todo9;
                todo.Todo10 = model.Todo10;
                todo.TodoDate1 = model.TodoDate1;
                todo.TodoDate2 = model.TodoDate2;
                todo.TodoDate3 = model.TodoDate3;
                todo.TodoDate4 = model.TodoDate4;
                todo.TodoDate5 = model.TodoDate5;
                todo.TodoDate6 = model.TodoDate6;
                todo.TodoDate7 = model.TodoDate7;
                todo.TodoDate8 = model.TodoDate8;
                todo.TodoDate9 = model.TodoDate9;
                todo.TodoDate10 = model.TodoDate10;
                todo.TodoDateName1 = model.TodoDateName1;
                todo.TodoDateName2 = model.TodoDateName2;
                todo.TodoDateName3 = model.TodoDateName3;
                todo.TodoDateName4 = model.TodoDateName4;
                todo.TodoDateName5 = model.TodoDateName5;
                todo.TodoDateName6 = model.TodoDateName6;
                todo.TodoDateName7 = model.TodoDateName7;
                todo.TodoDateName8 = model.TodoDateName8;
                todo.TodoDateName9 = model.TodoDateName9;
                todo.TodoDateName10 = model.TodoDateName10;
            }
            else
            {
                user.Todo = new Models.Todo
                {
                    Todo1 = model.Todo1,
                    Todo2 = model.Todo2,
                    Todo3 = model.Todo3,
                    Todo4 = model.Todo4,
                    Todo5 = model.Todo5,
                    Todo6 = model.Todo6,
                    Todo7 = model.Todo7,
                    Todo8 = model.Todo8,
                    Todo9 = model.Todo9,
                    Todo10 = model.Todo10,
                    TodoDate1 = model.TodoDate1,
                    TodoDate2 = model.TodoDate2,
                    TodoDate3 = model.TodoDate3,
                    TodoDate4 = model.TodoDate4,
                    TodoDate5 = model.TodoDate5,
                    TodoDate6 = model.TodoDate6,
                    TodoDate7 = model.TodoDate7,
                    TodoDate8 = model.TodoDate8,
                    TodoDate9 = model.TodoDate9,
                    TodoDate10 = model.TodoDate10,
                    TodoDateName1 = model.TodoDateName1,
                    TodoDateName2 = model.TodoDateName2,
                    TodoDateName3 = model.TodoDateName3,
                    TodoDateName4 = model.TodoDateName4,
                    TodoDateName5 = model.TodoDateName5,
                    TodoDateName6 = model.TodoDateName6,
                    TodoDateName7 = model.TodoDateName7,
                    TodoDateName8 = model.TodoDateName8,
                    TodoDateName9 = model.TodoDateName9,
                    TodoDateName10 = model.TodoDateName10,
                };
            }
            _context.SaveChanges();
            return View(model);
        }

        public ActionResult Birthday()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var familyBirthday = _context.FamilyBirthday.FirstOrDefault(x => x.Id == userId);
            var friendsBirthday = _context.FriendsBirthday.FirstOrDefault(x => x.Id == userId);
            var othersBirthday = _context.OthersBirthday.FirstOrDefault(x => x.Id == userId);
            BirthdayViewModelWrapper wrapper = new BirthdayViewModelWrapper();

            if (userProfile != null && familyBirthday != null && friendsBirthday != null && othersBirthday != null)
            {
                FamilyBirthdayViewModel FamilyBirthday = new FamilyBirthdayViewModel(familyBirthday);
                FriendsBirthdayViewModel FriendsBirthday = new FriendsBirthdayViewModel(friendsBirthday);
                OthersBirthdayViewModel OthersBirthday = new OthersBirthdayViewModel(othersBirthday);
                wrapper.FamilyBirthdayViewModel = FamilyBirthday;
                wrapper.FriendsBirthdayViewModel = FriendsBirthday;
                wrapper.OthersBirthdayViewModel = OthersBirthday;
                return View(wrapper);
            }

            if (userProfile != null && familyBirthday != null && friendsBirthday != null && othersBirthday == null)
            {
                FamilyBirthdayViewModel FamilyBirthday = new FamilyBirthdayViewModel(familyBirthday);
                FriendsBirthdayViewModel FriendsBirthday = new FriendsBirthdayViewModel(friendsBirthday);
                wrapper.FamilyBirthdayViewModel = FamilyBirthday;
                wrapper.FriendsBirthdayViewModel = FriendsBirthday;
                wrapper.OthersBirthdayViewModel = new OthersBirthdayViewModel();
                return View(wrapper);
            }
            else if (userProfile != null && familyBirthday != null && friendsBirthday == null && othersBirthday == null)
            {
                FamilyBirthdayViewModel FamilyBirthday = new FamilyBirthdayViewModel(familyBirthday);
                wrapper.FamilyBirthdayViewModel = FamilyBirthday;
                wrapper.FriendsBirthdayViewModel = new FriendsBirthdayViewModel();
                wrapper.OthersBirthdayViewModel = new OthersBirthdayViewModel();
                return View(wrapper);
            }
            else if (userProfile != null && familyBirthday == null && friendsBirthday != null && othersBirthday == null)
            {
                FriendsBirthdayViewModel FriendsBirthday = new FriendsBirthdayViewModel(friendsBirthday);
                wrapper.FamilyBirthdayViewModel = new FamilyBirthdayViewModel();
                wrapper.OthersBirthdayViewModel = new OthersBirthdayViewModel();
                return View(wrapper);
            }
            else if (userProfile != null && familyBirthday == null && friendsBirthday == null && othersBirthday != null)
            {
                OthersBirthdayViewModel OthersBirthday = new OthersBirthdayViewModel(othersBirthday);
                wrapper.FamilyBirthdayViewModel = new FamilyBirthdayViewModel();
                wrapper.FriendsBirthdayViewModel = new FriendsBirthdayViewModel();
                return View(wrapper);
            }
            else if (userProfile == null)
            {
                return RedirectToAction("Manage", "Profile");
            }
            else
            {
                wrapper.FamilyBirthdayViewModel = new FamilyBirthdayViewModel();
                wrapper.FriendsBirthdayViewModel = new FriendsBirthdayViewModel();
                wrapper.OthersBirthdayViewModel = new OthersBirthdayViewModel();
                return View(wrapper);
            }
        }
        [HttpGet]
        public ActionResult FamilyBirthdayEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var familyBirthday = _context.FamilyBirthday.FirstOrDefault(x => x.Id == userId);

            if (familyBirthday != null)
            {
                FamilyBirthdayViewModel model = new FamilyBirthdayViewModel(familyBirthday);
                return View(model);
            }
            else
            {
                FamilyBirthdayViewModel model = new FamilyBirthdayViewModel();
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult FamilyBirthdayEdit(FamilyBirthdayViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var familyBirthday = _context.FamilyBirthday.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            if (familyBirthday != null)
            {
                familyBirthday.FamilyBirthday1 = model.FamilyBirthday1;
                familyBirthday.FamilyBirthday2 = model.FamilyBirthday2;
                familyBirthday.FamilyBirthday3 = model.FamilyBirthday3;
                familyBirthday.FamilyBirthday4 = model.FamilyBirthday4;
                familyBirthday.FamilyBirthday5 = model.FamilyBirthday5;
                familyBirthday.FamilyBirthday6 = model.FamilyBirthday6;
                familyBirthday.FamilyBirthday7 = model.FamilyBirthday7;
                familyBirthday.FamilyBirthday8 = model.FamilyBirthday8;
                familyBirthday.FamilyBirthday9 = model.FamilyBirthday9;
                familyBirthday.FamilyBirthday10 = model.FamilyBirthday10;
                familyBirthday.FamilyBirthdayName1 = model.FamilyBirthdayName1;
                familyBirthday.FamilyBirthdayName2 = model.FamilyBirthdayName2;
                familyBirthday.FamilyBirthdayName3 = model.FamilyBirthdayName3;
                familyBirthday.FamilyBirthdayName4 = model.FamilyBirthdayName4;
                familyBirthday.FamilyBirthdayName5 = model.FamilyBirthdayName5;
                familyBirthday.FamilyBirthdayName6 = model.FamilyBirthdayName6;
                familyBirthday.FamilyBirthdayName7 = model.FamilyBirthdayName7;
                familyBirthday.FamilyBirthdayName8 = model.FamilyBirthdayName8;
                familyBirthday.FamilyBirthdayName9 = model.FamilyBirthdayName9;
                familyBirthday.FamilyBirthdayName10 = model.FamilyBirthdayName10;
            }
            else
            {
                user.FamilyBirthday = new Models.FamilyBirthday
                {
                    FamilyBirthday1 = model.FamilyBirthday1,
                    FamilyBirthday2 = model.FamilyBirthday2,
                    FamilyBirthday3 = model.FamilyBirthday3,
                    FamilyBirthday4 = model.FamilyBirthday4,
                    FamilyBirthday5 = model.FamilyBirthday5,
                    FamilyBirthday6 = model.FamilyBirthday6,
                    FamilyBirthday7 = model.FamilyBirthday7,
                    FamilyBirthday8 = model.FamilyBirthday8,
                    FamilyBirthday9 = model.FamilyBirthday9,
                    FamilyBirthday10 = model.FamilyBirthday10,
                    FamilyBirthdayName1 = model.FamilyBirthdayName1,
                    FamilyBirthdayName2 = model.FamilyBirthdayName2,
                    FamilyBirthdayName3 = model.FamilyBirthdayName3,
                    FamilyBirthdayName4 = model.FamilyBirthdayName4,
                    FamilyBirthdayName5 = model.FamilyBirthdayName5,
                    FamilyBirthdayName6 = model.FamilyBirthdayName6,
                    FamilyBirthdayName7 = model.FamilyBirthdayName7,
                    FamilyBirthdayName8 = model.FamilyBirthdayName8,
                    FamilyBirthdayName9 = model.FamilyBirthdayName9,
                    FamilyBirthdayName10 = model.FamilyBirthdayName10,
                };
            }
            _context.SaveChanges();
            return View(model);
        }

        [HttpGet]
        public ActionResult FriendsBirthdayEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var friendsBirthday = _context.FriendsBirthday.FirstOrDefault(x => x.Id == userId);

            if (friendsBirthday != null)
            {
                FriendsBirthdayViewModel model = new FriendsBirthdayViewModel(friendsBirthday);
                return View(model);
            }
            else
            {
                FriendsBirthdayViewModel model = new FriendsBirthdayViewModel();
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult FriendsBirthdayEdit(FriendsBirthdayViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var friendsBirthday = _context.FriendsBirthday.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            if (friendsBirthday != null)
            {
                friendsBirthday.FriendsBirthday1 = model.FriendsBirthday1;
                friendsBirthday.FriendsBirthday2 = model.FriendsBirthday2;
                friendsBirthday.FriendsBirthday3 = model.FriendsBirthday3;
                friendsBirthday.FriendsBirthday4 = model.FriendsBirthday4;
                friendsBirthday.FriendsBirthday5 = model.FriendsBirthday5;
                friendsBirthday.FriendsBirthday6 = model.FriendsBirthday6;
                friendsBirthday.FriendsBirthday7 = model.FriendsBirthday7;
                friendsBirthday.FriendsBirthday8 = model.FriendsBirthday8;
                friendsBirthday.FriendsBirthday9 = model.FriendsBirthday9;
                friendsBirthday.FriendsBirthday10 = model.FriendsBirthday10;
                friendsBirthday.FriendsBirthdayName1 = model.FriendsBirthdayName1;
                friendsBirthday.FriendsBirthdayName2 = model.FriendsBirthdayName2;
                friendsBirthday.FriendsBirthdayName3 = model.FriendsBirthdayName3;
                friendsBirthday.FriendsBirthdayName4 = model.FriendsBirthdayName4;
                friendsBirthday.FriendsBirthdayName5 = model.FriendsBirthdayName5;
                friendsBirthday.FriendsBirthdayName6 = model.FriendsBirthdayName6;
                friendsBirthday.FriendsBirthdayName7 = model.FriendsBirthdayName7;
                friendsBirthday.FriendsBirthdayName8 = model.FriendsBirthdayName8;
                friendsBirthday.FriendsBirthdayName9 = model.FriendsBirthdayName9;
                friendsBirthday.FriendsBirthdayName10 = model.FriendsBirthdayName10;
            }
            else
            {
                user.FriendsBirthday = new Models.FriendsBirthday
                {
                    FriendsBirthday1 = model.FriendsBirthday1,
                    FriendsBirthday2 = model.FriendsBirthday2,
                    FriendsBirthday3 = model.FriendsBirthday3,
                    FriendsBirthday4 = model.FriendsBirthday4,
                    FriendsBirthday5 = model.FriendsBirthday5,
                    FriendsBirthday6 = model.FriendsBirthday6,
                    FriendsBirthday7 = model.FriendsBirthday7,
                    FriendsBirthday8 = model.FriendsBirthday8,
                    FriendsBirthday9 = model.FriendsBirthday9,
                    FriendsBirthday10 = model.FriendsBirthday10,
                    FriendsBirthdayName1 = model.FriendsBirthdayName1,
                    FriendsBirthdayName2 = model.FriendsBirthdayName2,
                    FriendsBirthdayName3 = model.FriendsBirthdayName3,
                    FriendsBirthdayName4 = model.FriendsBirthdayName4,
                    FriendsBirthdayName5 = model.FriendsBirthdayName5,
                    FriendsBirthdayName6 = model.FriendsBirthdayName6,
                    FriendsBirthdayName7 = model.FriendsBirthdayName7,
                    FriendsBirthdayName8 = model.FriendsBirthdayName8,
                    FriendsBirthdayName9 = model.FriendsBirthdayName9,
                    FriendsBirthdayName10 = model.FriendsBirthdayName10,
                };
            }
            _context.SaveChanges();
            return View(model);
        }
        [HttpGet]
        public ActionResult OthersBirthdayEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var othersBirthday = _context.OthersBirthday.FirstOrDefault(x => x.Id == userId);

            if (othersBirthday != null)
            {
                OthersBirthdayViewModel model = new OthersBirthdayViewModel(othersBirthday);
                return View(model);
            }
            else
            {
                OthersBirthdayViewModel model = new OthersBirthdayViewModel();
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult OthersBirthdayEdit(OthersBirthdayViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var othersBirthday = _context.OthersBirthday.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            if (othersBirthday != null)
            {
                othersBirthday.OthersBirthday1 = model.OthersBirthday1;
                othersBirthday.OthersBirthday2 = model.OthersBirthday2;
                othersBirthday.OthersBirthday3 = model.OthersBirthday3;
                othersBirthday.OthersBirthday4 = model.OthersBirthday4;
                othersBirthday.OthersBirthday5 = model.OthersBirthday5;
                othersBirthday.OthersBirthday6 = model.OthersBirthday6;
                othersBirthday.OthersBirthday7 = model.OthersBirthday7;
                othersBirthday.OthersBirthday8 = model.OthersBirthday8;
                othersBirthday.OthersBirthday9 = model.OthersBirthday9;
                othersBirthday.OthersBirthday10 = model.OthersBirthday10;
                othersBirthday.OthersBirthdayName1 = model.OthersBirthdayName1;
                othersBirthday.OthersBirthdayName2 = model.OthersBirthdayName2;
                othersBirthday.OthersBirthdayName3 = model.OthersBirthdayName3;
                othersBirthday.OthersBirthdayName4 = model.OthersBirthdayName4;
                othersBirthday.OthersBirthdayName5 = model.OthersBirthdayName5;
                othersBirthday.OthersBirthdayName6 = model.OthersBirthdayName6;
                othersBirthday.OthersBirthdayName7 = model.OthersBirthdayName7;
                othersBirthday.OthersBirthdayName8 = model.OthersBirthdayName8;
                othersBirthday.OthersBirthdayName9 = model.OthersBirthdayName9;
                othersBirthday.OthersBirthdayName10 = model.OthersBirthdayName10;
            }
            else
            {
                user.OthersBirthday = new Models.OthersBirthday
                {
                    OthersBirthday1 = model.OthersBirthday1,
                    OthersBirthday2 = model.OthersBirthday2,
                    OthersBirthday3 = model.OthersBirthday3,
                    OthersBirthday4 = model.OthersBirthday4,
                    OthersBirthday5 = model.OthersBirthday5,
                    OthersBirthday6 = model.OthersBirthday6,
                    OthersBirthday7 = model.OthersBirthday7,
                    OthersBirthday8 = model.OthersBirthday8,
                    OthersBirthday9 = model.OthersBirthday9,
                    OthersBirthday10 = model.OthersBirthday10,
                    OthersBirthdayName1 = model.OthersBirthdayName1,
                    OthersBirthdayName2 = model.OthersBirthdayName2,
                    OthersBirthdayName3 = model.OthersBirthdayName3,
                    OthersBirthdayName4 = model.OthersBirthdayName4,
                    OthersBirthdayName5 = model.OthersBirthdayName5,
                    OthersBirthdayName6 = model.OthersBirthdayName6,
                    OthersBirthdayName7 = model.OthersBirthdayName7,
                    OthersBirthdayName8 = model.OthersBirthdayName8,
                    OthersBirthdayName9 = model.OthersBirthdayName9,
                    OthersBirthdayName10 = model.OthersBirthdayName10,
                };
            }
            _context.SaveChanges();
            return View(model);
        }

        public ActionResult Relationship()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var relationship = _context.Relationship.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null && relationship != null)
            {
                RelationshipViewModel model = new RelationshipViewModel(relationship);
                return View(model);
            }
            else if (userProfile != null && relationship == null)
            {
                RelationshipViewModel model = new RelationshipViewModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }
        [HttpGet]
        public ActionResult RelationshipEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var relationship = _context.Relationship.FirstOrDefault(x => x.Id == userId);

            if (relationship != null)
            {
                RelationshipViewModel model = new RelationshipViewModel(relationship);
                return View(model);

            }
            else
            {
                RelationshipViewModel model = new RelationshipViewModel();
                return View(model);

            }

        }
        [HttpPost]
        public ActionResult RelationshipEdit(RelationshipViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var relationship = _context.Relationship.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            if (relationship != null)
            {
                relationship.Relationship1 = model.Relationship1;
                relationship.Relationship2 = model.Relationship2;
                relationship.Relationship3 = model.Relationship3;
                relationship.Relationship4 = model.Relationship4;
                relationship.Relationship5 = model.Relationship5;
                relationship.Relationship6 = model.Relationship6;
                relationship.Relationship7 = model.Relationship7;
                relationship.Relationship8 = model.Relationship8;
                relationship.Relationship9 = model.Relationship9;
                relationship.Relationship10 = model.Relationship10;
            }
            else
            {
                user.Relationship = new Models.Relationship
                {
                    Relationship1 = model.Relationship1,
                    Relationship2 = model.Relationship2,
                    Relationship3 = model.Relationship3,
                    Relationship4 = model.Relationship4,
                    Relationship5 = model.Relationship5,
                    Relationship6 = model.Relationship6,
                    Relationship7 = model.Relationship7,
                    Relationship8 = model.Relationship8,
                    Relationship9 = model.Relationship9,
                    Relationship10 = model.Relationship10
                };
            }
            _context.SaveChanges();
            return View(model);
        }
        [HttpGet]
        public ActionResult Goals()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var goals = _context.Goals.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null && goals != null)
            {
                GoalsViewModel model = new GoalsViewModel(goals);
                return View(model);
            }
            if (userProfile != null && goals == null)
            {
                GoalsViewModel model = new GoalsViewModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }
        [HttpPost]
        public ActionResult Goals(GoalsViewModel model, string submitButton)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var goals = _context.Goals.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();
            switch (submitButton)
            {
                case "AGoal":
                    {
                        //Dla tych samych dat
                        if (goals.AGoalDate1 == null)
                        {
                            goals.AGoalDate1 = DateTime.Today;
                            goals.AGoal1 = model.AGoal1;
                            model.AGoalDate1 = goals.AGoalDate1;
                            model.AGoal1 = goals.AGoal1;
                        }
                        if (goals.AGoalDate1 != null && goals.AGoalDate1 == DateTime.Today)
                        {
                            goals.AGoalDate1 = DateTime.Today;
                            goals.AGoal1 = model.AGoal1;
                            model.AGoalDate1 = goals.AGoalDate1;
                            model.AGoal1 = goals.AGoal1;
                        }
                        if (goals.AGoalDate2 != null && goals.AGoalDate2 == DateTime.Today)
                        {
                            goals.AGoalDate2 = DateTime.Today;
                            goals.AGoal2 = model.AGoal1;
                            model.AGoalDate2 = goals.AGoalDate2;
                            model.AGoal2 = goals.AGoal2;
                        }
                        if (goals.AGoalDate3 != null && goals.AGoalDate3 == DateTime.Today)
                        {
                            goals.AGoalDate3 = DateTime.Today;
                            goals.AGoal3 = model.AGoal1;
                            model.AGoalDate3 = goals.AGoalDate3;
                            model.AGoal3 = goals.AGoal3;
                        }
                        if (goals.AGoalDate4 != null && goals.AGoalDate4 == DateTime.Today)
                        {
                            goals.AGoalDate4 = DateTime.Today;
                            goals.AGoal4 = model.AGoal1;
                            model.AGoalDate4 = goals.AGoalDate4;
                            model.AGoal4 = goals.AGoal4;
                        }
                        if (goals.AGoalDate5 != null && goals.AGoalDate5 == DateTime.Today)
                        {
                            goals.AGoalDate5 = DateTime.Today;
                            goals.AGoal5 = model.AGoal1;
                            model.AGoalDate5 = goals.AGoalDate5;
                            model.AGoal5 = goals.AGoal5;
                        }
                        if (goals.AGoalDate6 != null && goals.AGoalDate6 == DateTime.Today)
                        {
                            goals.AGoalDate6 = DateTime.Today;
                            goals.AGoal6 = model.AGoal1;
                            model.AGoalDate6 = goals.AGoalDate6;
                            model.AGoal6 = goals.AGoal6;
                        }
                        if (goals.AGoalDate7 != null && goals.AGoalDate7 == DateTime.Today)
                        {
                            goals.AGoalDate7 = DateTime.Today;
                            goals.AGoal7 = model.AGoal1;
                            model.AGoalDate7 = goals.AGoalDate7;
                            model.AGoal7 = goals.AGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.AGoalDate1 != null && goals.AGoalDate2 == null && goals.AGoalDate1 != DateTime.Today)
                        {
                            goals.AGoalDate2 = DateTime.Today;
                            goals.AGoal2 = model.AGoal1;
                            model.AGoalDate2 = goals.AGoalDate2;
                            model.AGoal2 = goals.AGoal2;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        else if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 == null && goals.AGoalDate2 != DateTime.Today)
                        {
                            goals.AGoalDate3 = DateTime.Today;
                            goals.AGoal3 = model.AGoal1;
                            model.AGoalDate3 = goals.AGoalDate3;
                            model.AGoal3 = goals.AGoal3;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        else if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 != null && goals.AGoalDate4 == null && goals.AGoalDate3 != DateTime.Today)
                        {
                            goals.AGoalDate4 = DateTime.Today;
                            goals.AGoal4 = model.AGoal1;
                            model.AGoalDate4 = goals.AGoalDate4;
                            model.AGoal4 = goals.AGoal4;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        else if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 != null && goals.AGoalDate4 != null && goals.AGoalDate5 == null && goals.AGoalDate4 != DateTime.Today)
                        {
                            goals.AGoalDate5 = DateTime.Today;
                            goals.AGoal5 = model.AGoal1;
                            model.AGoalDate5 = goals.AGoalDate5;
                            model.AGoal5 = goals.AGoal5;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 != null && goals.AGoalDate4 != null && goals.AGoalDate5 != null && goals.AGoalDate6 == null && goals.AGoalDate5 != DateTime.Today)
                        {
                            goals.AGoalDate6 = DateTime.Today;
                            goals.AGoal6 = model.AGoal1;
                            model.AGoalDate6 = goals.AGoalDate6;
                            model.AGoal6 = goals.AGoal6;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        if (goals.AGoalDate1 != null && goals.AGoalDate2 != null && goals.AGoalDate3 != null && goals.AGoalDate4 != null && goals.AGoalDate5 != null && goals.AGoalDate6 != null &&
                            goals.AGoalDate7 == null && goals.AGoalDate6 != DateTime.Today)
                        {
                            goals.AGoalDate7 = DateTime.Today;
                            goals.AGoal7 = model.AGoal1;
                            model.AGoalDate7 = goals.AGoalDate7;
                            model.AGoal7 = goals.AGoal7;
                            _context.SaveChanges();
                            return PartialView("_AGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.AGoalDate7 != null && goals.AGoalDate7 != DateTime.Today)
                        {
                            goals.AGoal1 = goals.AGoal2;
                            goals.AGoalDate1 = goals.AGoalDate2;
                            goals.AGoal2 = goals.AGoal3;
                            goals.AGoalDate2 = goals.AGoalDate3;
                            goals.AGoal3 = goals.AGoal4;
                            goals.AGoalDate3 = goals.AGoalDate4;
                            goals.AGoal4 = goals.AGoal5;
                            goals.AGoalDate4 = goals.AGoalDate5;
                            goals.AGoal5 = goals.AGoal6;
                            goals.AGoalDate5 = goals.AGoalDate6;
                            goals.AGoal6 = goals.AGoal7;
                            goals.AGoalDate6 = goals.AGoalDate7;
                            goals.AGoal7 = model.AGoal1;
                            goals.AGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_AGoalTable", model);
                        }

                        model = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_AGoalTable", model);
                    };
                //Dla B
                //Dla tych samych dat
                case "BGoal":
                    {
                        if (goals.BGoalDate1 == null)
                        {
                            goals.BGoalDate1 = DateTime.Today;
                            goals.BGoal1 = model.BGoal1;
                            model.BGoalDate1 = goals.BGoalDate1;
                            model.BGoal1 = goals.BGoal1;
                        }
                        if (goals.BGoalDate1 != null && goals.BGoalDate1 == DateTime.Today)
                        {
                            goals.BGoalDate1 = DateTime.Today;
                            goals.BGoal1 = model.BGoal1;
                            model.BGoalDate1 = goals.BGoalDate1;
                            model.BGoal1 = goals.BGoal1;
                        }
                        if (goals.BGoalDate2 != null && goals.BGoalDate2 == DateTime.Today)
                        {
                            goals.BGoalDate2 = DateTime.Today;
                            goals.BGoal2 = model.BGoal1;
                            model.BGoalDate2 = goals.BGoalDate2;
                            model.BGoal2 = goals.BGoal2;
                        }
                        if (goals.BGoalDate3 != null && goals.BGoalDate3 == DateTime.Today)
                        {
                            goals.BGoalDate3 = DateTime.Today;
                            goals.BGoal3 = model.BGoal1;
                            model.BGoalDate3 = goals.BGoalDate3;
                            model.BGoal3 = goals.BGoal3;
                        }
                        if (goals.BGoalDate4 != null && goals.BGoalDate4 == DateTime.Today)
                        {
                            goals.BGoalDate4 = DateTime.Today;
                            goals.BGoal4 = model.BGoal1;
                            model.BGoalDate4 = goals.BGoalDate4;
                            model.BGoal4 = goals.BGoal4;
                        }
                        if (goals.BGoalDate5 != null && goals.BGoalDate5 == DateTime.Today)
                        {
                            goals.BGoalDate5 = DateTime.Today;
                            goals.BGoal5 = model.BGoal1;
                            model.BGoalDate5 = goals.BGoalDate5;
                            model.BGoal5 = goals.BGoal5;
                        }
                        if (goals.BGoalDate6 != null && goals.BGoalDate6 == DateTime.Today)
                        {
                            goals.BGoalDate6 = DateTime.Today;
                            goals.BGoal6 = model.BGoal1;
                            model.BGoalDate6 = goals.BGoalDate6;
                            model.BGoal6 = goals.BGoal6;
                        }
                        if (goals.BGoalDate7 != null && goals.BGoalDate7 == DateTime.Today)
                        {
                            goals.BGoalDate7 = DateTime.Today;
                            goals.BGoal7 = model.BGoal1;
                            model.BGoalDate7 = goals.BGoalDate7;
                            model.BGoal7 = goals.BGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.BGoalDate1 != null && goals.BGoalDate2 == null && goals.BGoalDate1 != DateTime.Today)
                        {
                            goals.BGoalDate2 = DateTime.Today;
                            goals.BGoal2 = model.BGoal1;
                            model.BGoalDate2 = goals.BGoalDate2;
                            model.BGoal2 = goals.BGoal2;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);

                        }
                        else if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 == null && goals.BGoalDate2 != DateTime.Today)
                        {
                            goals.BGoalDate3 = DateTime.Today;
                            goals.BGoal3 = model.BGoal1;
                            model.BGoalDate3 = goals.BGoalDate3;
                            model.BGoal3 = goals.BGoal3;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        else if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 != null && goals.BGoalDate4 == null && goals.BGoalDate3 != DateTime.Today)
                        {
                            goals.BGoalDate4 = DateTime.Today;
                            goals.BGoal4 = model.BGoal1;
                            model.BGoalDate4 = goals.BGoalDate4;
                            model.BGoal4 = goals.BGoal4;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        else if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 != null && goals.BGoalDate4 != null && goals.BGoalDate5 == null && goals.BGoalDate4 != DateTime.Today)
                        {
                            goals.BGoalDate5 = DateTime.Today;
                            goals.BGoal5 = model.BGoal1;
                            model.BGoalDate5 = goals.BGoalDate5;
                            model.BGoal5 = goals.BGoal5;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 != null && goals.BGoalDate4 != null && goals.BGoalDate5 != null && goals.BGoalDate6 == null && goals.BGoalDate5 != DateTime.Today)
                        {
                            goals.BGoalDate6 = DateTime.Today;
                            goals.BGoal6 = model.BGoal1;
                            model.BGoalDate6 = goals.BGoalDate6;
                            model.BGoal6 = goals.BGoal6;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        if (goals.BGoalDate1 != null && goals.BGoalDate2 != null && goals.BGoalDate3 != null && goals.BGoalDate4 != null && goals.BGoalDate5 != null && goals.BGoalDate6 != null &&
                              goals.BGoalDate7 == null && goals.BGoalDate6 != DateTime.Today)
                        {
                            goals.BGoalDate7 = DateTime.Today;
                            goals.BGoal7 = model.BGoal1;
                            model.BGoalDate7 = goals.BGoalDate7;
                            model.BGoal7 = goals.BGoal7;
                            _context.SaveChanges();
                            return PartialView("_BGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.BGoalDate7 != null && goals.BGoalDate7 != DateTime.Today)
                        {
                            goals.BGoal1 = goals.BGoal2;
                            goals.BGoalDate1 = goals.BGoalDate2;
                            goals.BGoal2 = goals.BGoal3;
                            goals.BGoalDate2 = goals.BGoalDate3;
                            goals.BGoal3 = goals.BGoal4;
                            goals.BGoalDate3 = goals.BGoalDate4;
                            goals.BGoal4 = goals.BGoal5;
                            goals.BGoalDate4 = goals.BGoalDate5;
                            goals.BGoal5 = goals.BGoal6;
                            goals.BGoalDate5 = goals.BGoalDate6;
                            goals.BGoal6 = goals.BGoal7;
                            goals.BGoalDate6 = goals.BGoalDate7;
                            goals.BGoal7 = model.BGoal1;
                            goals.BGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_BGoalTable", model);
                        }
                        model = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_BGoalTable", model);
                    };
                case "CGoal":
                    {
                        if (goals.CGoalDate1 == null)
                        {
                            goals.CGoalDate1 = DateTime.Today;
                            goals.CGoal1 = model.CGoal1;
                            model.CGoalDate1 = goals.CGoalDate1;
                            model.CGoal1 = goals.CGoal1;
                        }
                        if (goals.CGoalDate1 != null && goals.CGoalDate1 == DateTime.Today)
                        {
                            goals.CGoalDate1 = DateTime.Today;
                            goals.CGoal1 = model.CGoal1;
                            model.CGoalDate1 = goals.CGoalDate1;
                            model.CGoal1 = goals.CGoal1;
                        }
                        if (goals.CGoalDate2 != null && goals.CGoalDate2 == DateTime.Today)
                        {
                            goals.CGoalDate2 = DateTime.Today;
                            goals.CGoal2 = model.CGoal1;
                            model.CGoalDate2 = goals.CGoalDate2;
                            model.CGoal2 = goals.CGoal2;
                        }
                        if (goals.CGoalDate3 != null && goals.CGoalDate3 == DateTime.Today)
                        {
                            goals.CGoalDate3 = DateTime.Today;
                            goals.CGoal3 = model.CGoal1;
                            model.CGoalDate3 = goals.CGoalDate3;
                            model.CGoal3 = goals.CGoal3;
                        }
                        if (goals.CGoalDate4 != null && goals.CGoalDate4 == DateTime.Today)
                        {
                            goals.CGoalDate4 = DateTime.Today;
                            goals.CGoal4 = model.CGoal1;
                            model.CGoalDate4 = goals.CGoalDate4;
                            model.CGoal4 = goals.CGoal4;
                        }
                        if (goals.CGoalDate5 != null && goals.CGoalDate5 == DateTime.Today)
                        {
                            goals.CGoalDate5 = DateTime.Today;
                            goals.CGoal5 = model.CGoal1;
                            model.CGoalDate5 = goals.CGoalDate5;
                            model.CGoal5 = goals.CGoal5;
                        }
                        if (goals.CGoalDate6 != null && goals.CGoalDate6 == DateTime.Today)
                        {
                            goals.CGoalDate6 = DateTime.Today;
                            goals.CGoal6 = model.CGoal1;
                            model.CGoalDate6 = goals.CGoalDate6;
                            model.CGoal6 = goals.CGoal6;
                        }
                        if (goals.CGoalDate7 != null && goals.CGoalDate7 == DateTime.Today)
                        {
                            goals.CGoalDate7 = DateTime.Today;
                            goals.CGoal7 = model.CGoal1;
                            model.CGoalDate7 = goals.CGoalDate7;
                            model.CGoal7 = goals.CGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.CGoalDate1 != null && goals.CGoalDate2 == null && goals.CGoalDate1 != DateTime.Today)
                        {
                            goals.CGoalDate2 = DateTime.Today;
                            goals.CGoal2 = model.CGoal1;
                            model.CGoalDate2 = goals.CGoalDate2;
                            model.CGoal2 = goals.CGoal2;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);

                        }
                        else if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 == null && goals.CGoalDate2 != DateTime.Today)
                        {
                            goals.CGoalDate3 = DateTime.Today;
                            goals.CGoal3 = model.CGoal1;
                            model.CGoalDate3 = goals.CGoalDate3;
                            model.CGoal3 = goals.CGoal3;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        else if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 != null && goals.CGoalDate4 == null && goals.CGoalDate3 != DateTime.Today)
                        {
                            goals.CGoalDate4 = DateTime.Today;
                            goals.CGoal4 = model.CGoal1;
                            model.CGoalDate4 = goals.CGoalDate4;
                            model.CGoal4 = goals.CGoal4;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        else if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 != null && goals.CGoalDate4 != null && goals.CGoalDate5 == null && goals.CGoalDate4 != DateTime.Today)
                        {
                            goals.CGoalDate5 = DateTime.Today;
                            goals.CGoal5 = model.CGoal1;
                            model.CGoalDate5 = goals.CGoalDate5;
                            model.CGoal5 = goals.CGoal5;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 != null && goals.CGoalDate4 != null && goals.CGoalDate5 != null && goals.CGoalDate6 == null && goals.CGoalDate5 != DateTime.Today)
                        {
                            goals.CGoalDate6 = DateTime.Today;
                            goals.CGoal6 = model.CGoal1;
                            model.CGoalDate6 = goals.CGoalDate6;
                            model.CGoal6 = goals.CGoal6;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        if (goals.CGoalDate1 != null && goals.CGoalDate2 != null && goals.CGoalDate3 != null && goals.CGoalDate4 != null && goals.CGoalDate5 != null && goals.CGoalDate6 != null &&
                            goals.CGoalDate7 == null && goals.CGoalDate6 != DateTime.Today)
                        {
                            goals.CGoalDate7 = DateTime.Today;
                            goals.CGoal7 = model.CGoal1;
                            model.CGoalDate7 = goals.CGoalDate7;
                            model.CGoal7 = goals.CGoal7;
                            _context.SaveChanges();
                            return PartialView("_CGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.CGoalDate7 != null && goals.CGoalDate7 != DateTime.Today)
                        {
                            goals.CGoal1 = goals.CGoal2;
                            goals.CGoalDate1 = goals.CGoalDate2;
                            goals.CGoal2 = goals.CGoal3;
                            goals.CGoalDate2 = goals.CGoalDate3;
                            goals.CGoal3 = goals.CGoal4;
                            goals.CGoalDate3 = goals.CGoalDate4;
                            goals.CGoal4 = goals.CGoal5;
                            goals.CGoalDate4 = goals.CGoalDate5;
                            goals.CGoal5 = goals.CGoal6;
                            goals.CGoalDate5 = goals.CGoalDate6;
                            goals.CGoal6 = goals.CGoal7;
                            goals.CGoalDate6 = goals.CGoalDate7;
                            goals.CGoal7 = model.CGoal1;
                            goals.CGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_CGoalTable", model);
                        }
                        model = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_CGoalTable", model);
                    };
                case "DGoal":
                    {
                        if (goals.DGoalDate1 == null)
                        {
                            goals.DGoalDate1 = DateTime.Today;
                            goals.DGoal1 = model.DGoal1;
                            model.DGoalDate1 = goals.DGoalDate1;
                            model.DGoal1 = goals.DGoal1;
                        }
                        if (goals.DGoalDate1 != null && goals.DGoalDate1 == DateTime.Today)
                        {
                            goals.DGoalDate1 = DateTime.Today;
                            goals.DGoal1 = model.DGoal1;
                            model.DGoalDate1 = goals.DGoalDate1;
                            model.DGoal1 = goals.DGoal1;
                        }
                        if (goals.DGoalDate2 != null && goals.DGoalDate2 == DateTime.Today)
                        {
                            goals.DGoalDate2 = DateTime.Today;
                            goals.DGoal2 = model.DGoal1;
                            model.DGoalDate2 = goals.DGoalDate2;
                            model.DGoal2 = goals.DGoal2;
                        }
                        if (goals.DGoalDate3 != null && goals.DGoalDate3 == DateTime.Today)
                        {
                            goals.DGoalDate3 = DateTime.Today;
                            goals.DGoal3 = model.DGoal1;
                            model.DGoalDate3 = goals.DGoalDate3;
                            model.DGoal3 = goals.DGoal3;
                        }
                        if (goals.DGoalDate4 != null && goals.DGoalDate4 == DateTime.Today)
                        {
                            goals.DGoalDate4 = DateTime.Today;
                            goals.DGoal4 = model.DGoal1;
                            model.DGoalDate4 = goals.DGoalDate4;
                            model.DGoal4 = goals.DGoal4;
                        }
                        if (goals.DGoalDate5 != null && goals.DGoalDate5 == DateTime.Today)
                        {
                            goals.DGoalDate5 = DateTime.Today;
                            goals.DGoal5 = model.DGoal1;
                            model.DGoalDate5 = goals.DGoalDate5;
                            model.DGoal5 = goals.DGoal5;
                        }
                        if (goals.DGoalDate6 != null && goals.DGoalDate6 == DateTime.Today)
                        {
                            goals.DGoalDate6 = DateTime.Today;
                            goals.DGoal6 = model.DGoal1;
                            model.DGoalDate6 = goals.DGoalDate6;
                            model.DGoal6 = goals.DGoal6;
                        }
                        if (goals.DGoalDate7 != null && goals.DGoalDate7 == DateTime.Today)
                        {
                            goals.DGoalDate7 = DateTime.Today;
                            goals.DGoal7 = model.DGoal1;
                            model.DGoalDate7 = goals.DGoalDate7;
                            model.DGoal7 = goals.DGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.DGoalDate1 != null && goals.DGoalDate2 == null && goals.DGoalDate1 != DateTime.Today)
                        {
                            goals.DGoalDate2 = DateTime.Today;
                            goals.DGoal2 = model.DGoal1;
                            model.DGoalDate2 = goals.DGoalDate2;
                            model.DGoal2 = goals.DGoal2;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);

                        }
                        else if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 == null && goals.DGoalDate2 != DateTime.Today)
                        {
                            goals.DGoalDate3 = DateTime.Today;
                            goals.DGoal3 = model.DGoal1;
                            model.DGoalDate3 = goals.DGoalDate3;
                            model.DGoal3 = goals.DGoal3;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        else if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 != null && goals.DGoalDate4 == null && goals.DGoalDate3 != DateTime.Today)
                        {
                            goals.DGoalDate4 = DateTime.Today;
                            goals.DGoal4 = model.DGoal1;
                            model.DGoalDate4 = goals.DGoalDate4;
                            model.DGoal4 = goals.DGoal4;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        else if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 != null && goals.DGoalDate4 != null && goals.DGoalDate5 == null && goals.DGoalDate4 != DateTime.Today)
                        {
                            goals.DGoalDate5 = DateTime.Today;
                            goals.DGoal5 = model.DGoal1;
                            model.DGoalDate5 = goals.DGoalDate5;
                            model.DGoal5 = goals.DGoal5;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 != null && goals.DGoalDate4 != null && goals.DGoalDate5 != null && goals.DGoalDate6 == null && goals.DGoalDate5 != DateTime.Today)
                        {
                            goals.DGoalDate6 = DateTime.Today;
                            goals.DGoal6 = model.DGoal1;
                            model.DGoalDate6 = goals.DGoalDate6;
                            model.DGoal6 = goals.DGoal6;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        if (goals.DGoalDate1 != null && goals.DGoalDate2 != null && goals.DGoalDate3 != null && goals.DGoalDate4 != null && goals.DGoalDate5 != null && goals.DGoalDate6 != null &&
                            goals.DGoalDate7 == null && goals.DGoalDate6 != DateTime.Today)
                        {
                            goals.DGoalDate7 = DateTime.Today;
                            goals.DGoal7 = model.DGoal1;
                            model.DGoalDate7 = goals.DGoalDate7;
                            model.DGoal7 = goals.DGoal7;
                            _context.SaveChanges();
                            return PartialView("_DGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.DGoalDate7 != null && goals.DGoalDate7 != DateTime.Today)
                        {
                            goals.DGoal1 = goals.DGoal2;
                            goals.DGoalDate1 = goals.DGoalDate2;
                            goals.DGoal2 = goals.DGoal3;
                            goals.DGoalDate2 = goals.DGoalDate3;
                            goals.DGoal3 = goals.DGoal4;
                            goals.DGoalDate3 = goals.DGoalDate4;
                            goals.DGoal4 = goals.DGoal5;
                            goals.DGoalDate4 = goals.DGoalDate5;
                            goals.DGoal5 = goals.DGoal6;
                            goals.DGoalDate5 = goals.DGoalDate6;
                            goals.DGoal6 = goals.DGoal7;
                            goals.DGoalDate6 = goals.DGoalDate7;
                            goals.DGoal7 = model.DGoal1;
                            goals.DGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_DGoalTable", model);
                        }
                        model = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_DGoalTable", model);
                    };
                case "EGoal":
                    {
                        if (goals.EGoalDate1 == null)
                        {
                            goals.EGoalDate1 = DateTime.Today;
                            goals.EGoal1 = model.EGoal1;
                            model.EGoalDate1 = goals.EGoalDate1;
                            model.EGoal1 = goals.EGoal1;
                        }
                        if (goals.EGoalDate1 != null && goals.EGoalDate1 == DateTime.Today)
                        {
                            goals.EGoalDate1 = DateTime.Today;
                            goals.EGoal1 = model.EGoal1;
                            model.EGoalDate1 = goals.EGoalDate1;
                            model.EGoal1 = goals.EGoal1;
                        }
                        if (goals.EGoalDate2 != null && goals.EGoalDate2 == DateTime.Today)
                        {
                            goals.EGoalDate2 = DateTime.Today;
                            goals.EGoal2 = model.EGoal1;
                            model.EGoalDate2 = goals.EGoalDate2;
                            model.EGoal2 = goals.EGoal2;
                        }
                        if (goals.EGoalDate3 != null && goals.EGoalDate3 == DateTime.Today)
                        {
                            goals.EGoalDate3 = DateTime.Today;
                            goals.EGoal3 = model.EGoal1;
                            model.EGoalDate3 = goals.EGoalDate3;
                            model.EGoal3 = goals.EGoal3;
                        }
                        if (goals.EGoalDate4 != null && goals.EGoalDate4 == DateTime.Today)
                        {
                            goals.EGoalDate4 = DateTime.Today;
                            goals.EGoal4 = model.EGoal1;
                            model.EGoalDate4 = goals.EGoalDate4;
                            model.EGoal4 = goals.EGoal4;
                        }
                        if (goals.EGoalDate5 != null && goals.EGoalDate5 == DateTime.Today)
                        {
                            goals.EGoalDate5 = DateTime.Today;
                            goals.EGoal5 = model.EGoal1;
                            model.EGoalDate5 = goals.EGoalDate5;
                            model.EGoal5 = goals.EGoal5;
                        }
                        if (goals.EGoalDate6 != null && goals.EGoalDate6 == DateTime.Today)
                        {
                            goals.EGoalDate6 = DateTime.Today;
                            goals.EGoal6 = model.EGoal1;
                            model.EGoalDate6 = goals.EGoalDate6;
                            model.EGoal6 = goals.EGoal6;
                        }
                        if (goals.EGoalDate7 != null && goals.EGoalDate7 == DateTime.Today)
                        {
                            goals.EGoalDate7 = DateTime.Today;
                            goals.EGoal7 = model.EGoal1;
                            model.EGoalDate7 = goals.EGoalDate7;
                            model.EGoal7 = goals.EGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.EGoalDate1 != null && goals.EGoalDate2 == null && goals.EGoalDate1 != DateTime.Today)
                        {
                            goals.EGoalDate2 = DateTime.Today;
                            goals.EGoal2 = model.EGoal1;
                            model.EGoalDate2 = goals.EGoalDate2;
                            model.EGoal2 = goals.EGoal2;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);

                        }
                        else if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 == null && goals.EGoalDate2 != DateTime.Today)
                        {
                            goals.EGoalDate3 = DateTime.Today;
                            goals.EGoal3 = model.EGoal1;
                            model.EGoalDate3 = goals.EGoalDate3;
                            model.EGoal3 = goals.EGoal3;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        else if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 != null && goals.EGoalDate4 == null && goals.EGoalDate3 != DateTime.Today)
                        {
                            goals.EGoalDate4 = DateTime.Today;
                            goals.EGoal4 = model.EGoal1;
                            model.EGoalDate4 = goals.EGoalDate4;
                            model.EGoal4 = goals.EGoal4;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        else if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 != null && goals.EGoalDate4 != null && goals.EGoalDate5 == null && goals.EGoalDate4 != DateTime.Today)
                        {
                            goals.EGoalDate5 = DateTime.Today;
                            goals.EGoal5 = model.EGoal1;
                            model.EGoalDate5 = goals.EGoalDate5;
                            model.EGoal5 = goals.EGoal5;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 != null && goals.EGoalDate4 != null && goals.EGoalDate5 != null && goals.EGoalDate6 == null && goals.EGoalDate5 != DateTime.Today)
                        {
                            goals.EGoalDate6 = DateTime.Today;
                            goals.EGoal6 = model.EGoal1;
                            model.EGoalDate6 = goals.EGoalDate6;
                            model.EGoal6 = goals.EGoal6;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        if (goals.EGoalDate1 != null && goals.EGoalDate2 != null && goals.EGoalDate3 != null && goals.EGoalDate4 != null && goals.EGoalDate5 != null && goals.EGoalDate6 != null &&
                           goals.EGoalDate7 == null && goals.EGoalDate6 != DateTime.Today)
                        {
                            goals.EGoalDate7 = DateTime.Today;
                            goals.EGoal7 = model.EGoal1;
                            model.EGoalDate7 = goals.EGoalDate7;
                            model.EGoal7 = goals.EGoal7;
                            _context.SaveChanges();
                            return PartialView("_EGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.EGoalDate7 != null && goals.EGoalDate7 != DateTime.Today)
                        {
                            goals.EGoal1 = goals.EGoal2;
                            goals.EGoalDate1 = goals.EGoalDate2;
                            goals.EGoal2 = goals.EGoal3;
                            goals.EGoalDate2 = goals.EGoalDate3;
                            goals.EGoal3 = goals.EGoal4;
                            goals.EGoalDate3 = goals.EGoalDate4;
                            goals.EGoal4 = goals.EGoal5;
                            goals.EGoalDate4 = goals.EGoalDate5;
                            goals.EGoal5 = goals.EGoal6;
                            goals.EGoalDate5 = goals.EGoalDate6;
                            goals.EGoal6 = goals.EGoal7;
                            goals.EGoalDate6 = goals.EGoalDate7;
                            goals.EGoal7 = model.EGoal1;
                            goals.EGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_EGoalTable", model);
                        }
                        model = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_EGoalTable", model);
                    };
                case "FGoal":
                    {
                        if (goals.FGoalDate1 == null)
                        {
                            goals.FGoalDate1 = DateTime.Today;
                            goals.FGoal1 = model.FGoal1;
                            model.FGoalDate1 = goals.FGoalDate1;
                            model.FGoal1 = goals.FGoal1;
                        }
                        if (goals.FGoalDate1 != null && goals.FGoalDate1 == DateTime.Today)
                        {
                            goals.FGoalDate1 = DateTime.Today;
                            goals.FGoal1 = model.FGoal1;
                            model.FGoalDate1 = goals.FGoalDate1;
                            model.FGoal1 = goals.FGoal1;
                        }
                        if (goals.FGoalDate2 != null && goals.FGoalDate2 == DateTime.Today)
                        {
                            goals.FGoalDate2 = DateTime.Today;
                            goals.FGoal2 = model.FGoal1;
                            model.FGoalDate2 = goals.FGoalDate2;
                            model.FGoal2 = goals.FGoal2;
                        }
                        if (goals.FGoalDate3 != null && goals.FGoalDate3 == DateTime.Today)
                        {
                            goals.FGoalDate3 = DateTime.Today;
                            goals.FGoal3 = model.FGoal1;
                            model.FGoalDate3 = goals.FGoalDate3;
                            model.FGoal3 = goals.FGoal3;
                        }
                        if (goals.FGoalDate4 != null && goals.FGoalDate4 == DateTime.Today)
                        {
                            goals.FGoalDate4 = DateTime.Today;
                            goals.FGoal4 = model.FGoal1;
                            model.FGoalDate4 = goals.FGoalDate4;
                            model.FGoal4 = goals.FGoal4;
                        }
                        if (goals.FGoalDate5 != null && goals.FGoalDate5 == DateTime.Today)
                        {
                            goals.FGoalDate5 = DateTime.Today;
                            goals.FGoal5 = model.FGoal1;
                            model.FGoalDate5 = goals.FGoalDate5;
                            model.FGoal5 = goals.FGoal5;
                        }
                        if (goals.FGoalDate6 != null && goals.FGoalDate6 == DateTime.Today)
                        {
                            goals.FGoalDate6 = DateTime.Today;
                            goals.FGoal6 = model.FGoal1;
                            model.FGoalDate6 = goals.FGoalDate6;
                            model.FGoal6 = goals.FGoal6;
                        }
                        if (goals.FGoalDate7 != null && goals.FGoalDate7 == DateTime.Today)
                        {
                            goals.FGoalDate7 = DateTime.Today;
                            goals.FGoal7 = model.FGoal1;
                            model.FGoalDate7 = goals.FGoalDate7;
                            model.FGoal7 = goals.FGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.FGoalDate1 != null && goals.FGoalDate2 == null && goals.FGoalDate1 != DateTime.Today)
                        {
                            goals.FGoalDate2 = DateTime.Today;
                            goals.FGoal2 = model.FGoal1;
                            model.FGoalDate2 = goals.FGoalDate2;
                            model.FGoal2 = goals.FGoal2;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);

                        }
                        else if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 == null && goals.FGoalDate2 != DateTime.Today)
                        {
                            goals.FGoalDate3 = DateTime.Today;
                            goals.FGoal3 = model.FGoal1;
                            model.FGoalDate3 = goals.FGoalDate3;
                            model.FGoal3 = goals.FGoal3;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        else if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 != null && goals.FGoalDate4 == null && goals.FGoalDate3 != DateTime.Today)
                        {
                            goals.FGoalDate4 = DateTime.Today;
                            goals.FGoal4 = model.FGoal1;
                            model.FGoalDate4 = goals.FGoalDate4;
                            model.FGoal4 = goals.FGoal4;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        else if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 != null && goals.FGoalDate4 != null && goals.FGoalDate5 == null && goals.FGoalDate4 != DateTime.Today)
                        {
                            goals.FGoalDate5 = DateTime.Today;
                            goals.FGoal5 = model.FGoal1;
                            model.FGoalDate5 = goals.FGoalDate5;
                            model.FGoal5 = goals.FGoal5;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 != null && goals.FGoalDate4 != null && goals.FGoalDate5 != null && goals.FGoalDate6 == null && goals.FGoalDate5 != DateTime.Today)
                        {
                            goals.FGoalDate6 = DateTime.Today;
                            goals.FGoal6 = model.FGoal1;
                            model.FGoalDate6 = goals.FGoalDate6;
                            model.FGoal6 = goals.FGoal6;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        if (goals.FGoalDate1 != null && goals.FGoalDate2 != null && goals.FGoalDate3 != null && goals.FGoalDate4 != null && goals.FGoalDate5 != null && goals.FGoalDate6 != null &&
                           goals.FGoalDate7 == null && goals.FGoalDate6 != DateTime.Today)
                        {
                            goals.FGoalDate7 = DateTime.Today;
                            goals.FGoal7 = model.FGoal1;
                            model.FGoalDate7 = goals.FGoalDate7;
                            model.FGoal7 = goals.FGoal7;
                            _context.SaveChanges();
                            return PartialView("_FGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.FGoalDate7 != null && goals.FGoalDate7 != DateTime.Today)
                        {
                            goals.FGoal1 = goals.FGoal2;
                            goals.FGoalDate1 = goals.FGoalDate2;
                            goals.FGoal2 = goals.FGoal3;
                            goals.FGoalDate2 = goals.FGoalDate3;
                            goals.FGoal3 = goals.FGoal4;
                            goals.FGoalDate3 = goals.FGoalDate4;
                            goals.FGoal4 = goals.FGoal5;
                            goals.FGoalDate4 = goals.FGoalDate5;
                            goals.FGoal5 = goals.FGoal6;
                            goals.FGoalDate5 = goals.FGoalDate6;
                            goals.FGoal6 = goals.FGoal7;
                            goals.FGoalDate6 = goals.FGoalDate7;
                            goals.FGoal7 = model.FGoal1;
                            goals.FGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_FGoalTable", model);
                        }
                        model = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_FGoalTable", model);
                    };
                case "GGoal":
                    {
                        if (goals.GGoalDate1 == null)
                        {
                            goals.GGoalDate1 = DateTime.Today;
                            goals.GGoal1 = model.GGoal1;
                            model.GGoalDate1 = goals.GGoalDate1;
                            model.GGoal1 = goals.GGoal1;
                        }
                        if (goals.GGoalDate1 != null && goals.GGoalDate1 == DateTime.Today)
                        {
                            goals.GGoalDate1 = DateTime.Today;
                            goals.GGoal1 = model.GGoal1;
                            model.GGoalDate1 = goals.GGoalDate1;
                            model.GGoal1 = goals.GGoal1;
                        }
                        if (goals.GGoalDate2 != null && goals.GGoalDate2 == DateTime.Today)
                        {
                            goals.GGoalDate2 = DateTime.Today;
                            goals.GGoal2 = model.GGoal1;
                            model.GGoalDate2 = goals.GGoalDate2;
                            model.GGoal2 = goals.GGoal2;
                        }
                        if (goals.GGoalDate3 != null && goals.GGoalDate3 == DateTime.Today)
                        {
                            goals.GGoalDate3 = DateTime.Today;
                            goals.GGoal3 = model.GGoal1;
                            model.GGoalDate3 = goals.GGoalDate3;
                            model.GGoal3 = goals.GGoal3;
                        }
                        if (goals.GGoalDate4 != null && goals.GGoalDate4 == DateTime.Today)
                        {
                            goals.GGoalDate4 = DateTime.Today;
                            goals.GGoal4 = model.GGoal1;
                            model.GGoalDate4 = goals.GGoalDate4;
                            model.GGoal4 = goals.GGoal4;
                        }
                        if (goals.GGoalDate5 != null && goals.GGoalDate5 == DateTime.Today)
                        {
                            goals.GGoalDate5 = DateTime.Today;
                            goals.GGoal5 = model.GGoal1;
                            model.GGoalDate5 = goals.GGoalDate5;
                            model.GGoal5 = goals.GGoal5;
                        }
                        if (goals.GGoalDate6 != null && goals.GGoalDate6 == DateTime.Today)
                        {
                            goals.GGoalDate6 = DateTime.Today;
                            goals.GGoal6 = model.GGoal1;
                            model.GGoalDate6 = goals.GGoalDate6;
                            model.GGoal6 = goals.GGoal6;
                        }
                        if (goals.GGoalDate7 != null && goals.GGoalDate7 == DateTime.Today)
                        {
                            goals.GGoalDate7 = DateTime.Today;
                            goals.GGoal7 = model.GGoal1;
                            model.GGoalDate7 = goals.GGoalDate7;
                            model.GGoal7 = goals.GGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.GGoalDate1 != null && goals.GGoalDate2 == null && goals.GGoalDate1 != DateTime.Today)
                        {
                            goals.GGoalDate2 = DateTime.Today;
                            goals.GGoal2 = model.GGoal1;
                            model.GGoalDate2 = goals.GGoalDate2;
                            model.GGoal2 = goals.GGoal2;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);

                        }
                        else if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 == null && goals.GGoalDate2 != DateTime.Today)
                        {
                            goals.GGoalDate3 = DateTime.Today;
                            goals.GGoal3 = model.GGoal1;
                            model.GGoalDate3 = goals.GGoalDate3;
                            model.GGoal3 = goals.GGoal3;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        else if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 != null && goals.GGoalDate4 == null && goals.GGoalDate3 != DateTime.Today)
                        {
                            goals.GGoalDate4 = DateTime.Today;
                            goals.GGoal4 = model.GGoal1;
                            model.GGoalDate4 = goals.GGoalDate4;
                            model.GGoal4 = goals.GGoal4;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        else if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 != null && goals.GGoalDate4 != null && goals.GGoalDate5 == null && goals.GGoalDate4 != DateTime.Today)
                        {
                            goals.GGoalDate5 = DateTime.Today;
                            goals.GGoal5 = model.GGoal1;
                            model.GGoalDate5 = goals.GGoalDate5;
                            model.GGoal5 = goals.GGoal5;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 != null && goals.GGoalDate4 != null && goals.GGoalDate5 != null && goals.GGoalDate6 == null && goals.GGoalDate5 != DateTime.Today)
                        {
                            goals.GGoalDate6 = DateTime.Today;
                            goals.GGoal6 = model.GGoal1;
                            model.GGoalDate6 = goals.GGoalDate6;
                            model.GGoal6 = goals.GGoal6;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        if (goals.GGoalDate1 != null && goals.GGoalDate2 != null && goals.GGoalDate3 != null && goals.GGoalDate4 != null && goals.GGoalDate5 != null && goals.GGoalDate6 != null &&
                           goals.GGoalDate7 == null && goals.GGoalDate6 != DateTime.Today)
                        {
                            goals.GGoalDate7 = DateTime.Today;
                            goals.GGoal7 = model.GGoal1;
                            model.GGoalDate7 = goals.GGoalDate7;
                            model.GGoal7 = goals.GGoal7;
                            _context.SaveChanges();
                            return PartialView("_GGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.GGoalDate7 != null && goals.GGoalDate7 != DateTime.Today)
                        {
                            goals.GGoal1 = goals.GGoal2;
                            goals.GGoalDate1 = goals.GGoalDate2;
                            goals.GGoal2 = goals.GGoal3;
                            goals.GGoalDate2 = goals.GGoalDate3;
                            goals.GGoal3 = goals.GGoal4;
                            goals.GGoalDate3 = goals.GGoalDate4;
                            goals.GGoal4 = goals.GGoal5;
                            goals.GGoalDate4 = goals.GGoalDate5;
                            goals.GGoal5 = goals.GGoal6;
                            goals.GGoalDate5 = goals.GGoalDate6;
                            goals.GGoal6 = goals.GGoal7;
                            goals.GGoalDate6 = goals.GGoalDate7;
                            goals.GGoal7 = model.GGoal1;
                            goals.GGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_GGoalTable", model);
                        }
                        model = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_GGoalTable", model);
                    };
                case "HGoal":
                    {
                        if (goals.HGoalDate1 == null)
                        {
                            goals.HGoalDate1 = DateTime.Today;
                            goals.HGoal1 = model.HGoal1;
                            model.HGoalDate1 = goals.HGoalDate1;
                            model.HGoal1 = goals.HGoal1;
                        }
                        if (goals.HGoalDate1 != null && goals.HGoalDate1 == DateTime.Today)
                        {
                            goals.HGoalDate1 = DateTime.Today;
                            goals.HGoal1 = model.HGoal1;
                            model.HGoalDate1 = goals.HGoalDate1;
                            model.HGoal1 = goals.HGoal1;
                        }
                        if (goals.HGoalDate2 != null && goals.HGoalDate2 == DateTime.Today)
                        {
                            goals.HGoalDate2 = DateTime.Today;
                            goals.HGoal2 = model.HGoal1;
                            model.HGoalDate2 = goals.HGoalDate2;
                            model.HGoal2 = goals.HGoal2;
                        }
                        if (goals.HGoalDate3 != null && goals.HGoalDate3 == DateTime.Today)
                        {
                            goals.HGoalDate3 = DateTime.Today;
                            goals.HGoal3 = model.HGoal1;
                            model.HGoalDate3 = goals.HGoalDate3;
                            model.HGoal3 = goals.HGoal3;
                        }
                        if (goals.HGoalDate4 != null && goals.HGoalDate4 == DateTime.Today)
                        {
                            goals.HGoalDate4 = DateTime.Today;
                            goals.HGoal4 = model.HGoal1;
                            model.HGoalDate4 = goals.HGoalDate4;
                            model.HGoal4 = goals.HGoal4;
                        }
                        if (goals.HGoalDate5 != null && goals.HGoalDate5 == DateTime.Today)
                        {
                            goals.HGoalDate5 = DateTime.Today;
                            goals.HGoal5 = model.HGoal1;
                            model.HGoalDate5 = goals.HGoalDate5;
                            model.HGoal5 = goals.HGoal5;
                        }
                        if (goals.HGoalDate6 != null && goals.HGoalDate6 == DateTime.Today)
                        {
                            goals.HGoalDate6 = DateTime.Today;
                            goals.HGoal6 = model.HGoal1;
                            model.HGoalDate6 = goals.HGoalDate6;
                            model.HGoal6 = goals.HGoal6;
                        }
                        if (goals.HGoalDate7 != null && goals.HGoalDate7 == DateTime.Today)
                        {
                            goals.HGoalDate7 = DateTime.Today;
                            goals.HGoal7 = model.HGoal1;
                            model.HGoalDate7 = goals.HGoalDate7;
                            model.HGoal7 = goals.HGoal7;
                        }
                        //Dla wolnych miejsc
                        if (goals.HGoalDate1 != null && goals.HGoalDate2 == null && goals.HGoalDate1 != DateTime.Today)
                        {
                            goals.HGoalDate2 = DateTime.Today;
                            goals.HGoal2 = model.HGoal1;
                            model.HGoalDate2 = goals.HGoalDate2;
                            model.HGoal2 = goals.HGoal2;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);

                        }
                        else if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 == null && goals.HGoalDate2 != DateTime.Today)
                        {
                            goals.HGoalDate3 = DateTime.Today;
                            goals.HGoal3 = model.HGoal1;
                            model.HGoalDate3 = goals.HGoalDate3;
                            model.HGoal3 = goals.HGoal3;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        else if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 != null && goals.HGoalDate4 == null && goals.HGoalDate3 != DateTime.Today)
                        {
                            goals.HGoalDate4 = DateTime.Today;
                            goals.HGoal4 = model.HGoal1;
                            model.HGoalDate4 = goals.HGoalDate4;
                            model.HGoal4 = goals.HGoal4;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        else if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 != null && goals.HGoalDate4 != null && goals.HGoalDate5 == null && goals.HGoalDate4 != DateTime.Today)
                        {
                            goals.HGoalDate5 = DateTime.Today;
                            goals.HGoal5 = model.HGoal1;
                            model.HGoalDate5 = goals.HGoalDate5;
                            model.HGoal5 = goals.HGoal5;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 != null && goals.HGoalDate4 != null && goals.HGoalDate5 != null && goals.HGoalDate6 == null && goals.HGoalDate5 != DateTime.Today)
                        {
                            goals.HGoalDate6 = DateTime.Today;
                            goals.HGoal6 = model.HGoal1;
                            model.HGoalDate6 = goals.HGoalDate6;
                            model.HGoal6 = goals.HGoal6;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        if (goals.HGoalDate1 != null && goals.HGoalDate2 != null && goals.HGoalDate3 != null && goals.HGoalDate4 != null && goals.HGoalDate5 != null && goals.HGoalDate6 != null &&
                           goals.HGoalDate7 == null && goals.HGoalDate6 != DateTime.Today)
                        {
                            goals.HGoalDate7 = DateTime.Today;
                            goals.HGoal7 = model.HGoal1;
                            model.HGoalDate7 = goals.HGoalDate7;
                            model.HGoal7 = goals.HGoal7;
                            _context.SaveChanges();
                            return PartialView("_HGoalTable", model);
                        }
                        //Dla zajętych
                        if (goals.HGoalDate7 != null && goals.HGoalDate7 != DateTime.Today)
                        {
                            goals.HGoal1 = goals.HGoal2;
                            goals.HGoalDate1 = goals.HGoalDate2;
                            goals.HGoal2 = goals.HGoal3;
                            goals.HGoalDate2 = goals.HGoalDate3;
                            goals.HGoal3 = goals.HGoal4;
                            goals.HGoalDate3 = goals.HGoalDate4;
                            goals.HGoal4 = goals.HGoal5;
                            goals.HGoalDate4 = goals.HGoalDate5;
                            goals.HGoal5 = goals.HGoal6;
                            goals.HGoalDate5 = goals.HGoalDate6;
                            goals.HGoal6 = goals.HGoal7;
                            goals.HGoalDate6 = goals.HGoalDate7;
                            goals.HGoal7 = model.HGoal1;
                            goals.HGoalDate7 = DateTime.Today;
                            _context.SaveChanges();
                            //model.GoalsViewModel = new GoalsViewModel(goals1);
                            return PartialView("_HGoalTable", model);
                        }
                        model = new GoalsViewModel(goals);
                        _context.SaveChanges();
                        return PartialView("_HGoalTable", model);
                    };
                default:
                    return PartialView("_BGoalTable", model);
            }
        }


        [HttpGet]
        public ActionResult GoalsEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var goals = _context.Goals.FirstOrDefault(x => x.Id == userId);

            if (goals != null)
            {
                GoalsViewModel model = new GoalsViewModel(goals);
                return View(model);
            }
            else
            {
                GoalsViewModel model = new GoalsViewModel();
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult GoalsEdit(GoalsViewModel model, string submitButton)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var goals = _context.Goals.FirstOrDefault(x => x.Id == userId);
            if (user == null)
                return View();
            switch (submitButton)
            {
                case "AGoal":
                    {
                        if (goals != null && model.AGoalName != null && goals.AGoalName != null)
                        {
                            goals.AGoalName = model.AGoalName;
                            goals.AGoalQuestion = model.AGoalQuestion;
                        }
                        if (goals != null && model.AGoalName == null && goals.AGoalName != null)
                        {
                            goals.AGoalName = model.AGoalName;
                            goals.AGoalQuestion = model.AGoalQuestion;
                        }
                        if (goals != null && model.AGoalName != null && goals.AGoalName == null)
                        {
                            goals.AGoalName = model.AGoalName;
                            goals.AGoalQuestion = model.AGoalQuestion;
                        }
                        if (goals == null && model.AGoalName != null)
                        {
                            user.Goals = new Models.Goals
                            {
                                AGoalName = model.AGoalName,
                                AGoalQuestion = model.AGoalQuestion,
                            };
                        }
                        if (goals == null && model.AGoalName == null)
                        { }
                        _context.SaveChanges();
                        return PartialView("_AGoalWelcome", model);

                    };
                case "BGoal":
                    {
                        if (goals != null && model.BGoalName != null && goals.BGoalName != null)
                        {
                            goals.BGoalName = model.BGoalName;
                            goals.BGoalQuestion = model.BGoalQuestion;
                        }
                        if (goals != null && model.BGoalName == null && goals.BGoalName != null)
                        {
                            goals.BGoalName = model.BGoalName;
                            goals.BGoalQuestion = model.BGoalQuestion;
                        }
                        if (goals != null && model.BGoalName != null && goals.BGoalName == null)
                        {
                            goals.BGoalName = model.BGoalName;
                            goals.BGoalQuestion = model.BGoalQuestion;
                        }
                        if (goals == null && model.BGoalName != null)
                        {
                            user.Goals = new Models.Goals
                            {
                                BGoalName = model.BGoalName,
                                BGoalQuestion = model.BGoalQuestion,
                            };
                        }
                        if (goals == null && model.BGoalName == null)
                        { }
                        _context.SaveChanges();
                        return PartialView("_BGoalWelcome", model);
                    };
                case "CGoal":
                    {
                        if (goals != null && model.CGoalName != null && goals.CGoalName != null)
                        {
                            goals.CGoalName = model.CGoalName;
                            goals.CGoalQuestion = model.CGoalQuestion;
                        }
                        if (goals != null && model.CGoalName == null && goals.CGoalName != null)
                        {
                            goals.CGoalName = model.CGoalName;
                            goals.CGoalQuestion = model.CGoalQuestion;
                        }
                        if (goals != null && model.CGoalName != null && goals.CGoalName == null)
                        {
                            goals.CGoalName = model.CGoalName;
                            goals.CGoalQuestion = model.CGoalQuestion;
                        }
                        if (goals == null && model.CGoalName != null)
                        {
                            user.Goals = new Models.Goals
                            {
                                CGoalName = model.CGoalName,
                                CGoalQuestion = model.CGoalQuestion,
                            };
                        }
                        if (goals == null && model.CGoalName == null)
                        { }
                        _context.SaveChanges();
                        return PartialView("_CGoalWelcome", model);
                    };
                case "DGoal":
                    {
                        if (goals != null && model.DGoalName != null && goals.DGoalName != null)
                        {
                            goals.DGoalName = model.DGoalName;
                            goals.DGoalQuestion = model.DGoalQuestion;
                        }
                        if (goals != null && model.DGoalName == null && goals.DGoalName != null)
                        {
                            goals.DGoalName = model.DGoalName;
                            goals.DGoalQuestion = model.DGoalQuestion;
                        }
                        if (goals != null && model.DGoalName != null && goals.DGoalName == null)
                        {
                            goals.DGoalName = model.DGoalName;
                            goals.DGoalQuestion = model.DGoalQuestion;
                        }
                        if (goals == null && model.DGoalName != null)
                        {
                            user.Goals = new Models.Goals
                            {
                                DGoalName = model.DGoalName,
                                DGoalQuestion = model.DGoalQuestion,
                            };
                        }
                        if (goals == null && model.DGoalName == null)
                        { }
                        _context.SaveChanges();
                        return PartialView("_DGoalWelcome", model);
                    };
                case "EGoal":
                    {
                        if (goals != null && model.EGoalName != null && goals.EGoalName != null)
                        {
                            goals.EGoalName = model.EGoalName;
                            goals.EGoalQuestion = model.EGoalQuestion;
                        }
                        if (goals != null && model.EGoalName == null && goals.EGoalName != null)
                        {
                            goals.EGoalName = model.EGoalName;
                            goals.EGoalQuestion = model.EGoalQuestion;
                        }
                        if (goals != null && model.EGoalName != null && goals.EGoalName == null)
                        {
                            goals.EGoalName = model.EGoalName;
                            goals.EGoalQuestion = model.EGoalQuestion;
                        }
                        if (goals == null && model.EGoalName != null)
                        {
                            user.Goals = new Goals
                            {
                                EGoalName = model.EGoalName,
                                EGoalQuestion = model.EGoalQuestion,
                            };
                        }
                        if (goals == null && model.EGoalName == null)
                        { }
                        _context.SaveChanges();
                        return PartialView("_EGoalWelcome", model);
                    };
                case "FGoal":
                    {
                        if (goals != null && model.FGoalName != null && goals.FGoalName != null)
                        {
                            goals.FGoalName = model.FGoalName;
                            goals.FGoalQuestion = model.FGoalQuestion;
                        }
                        if (goals != null && model.FGoalName == null && goals.FGoalName != null)
                        {
                            goals.FGoalName = model.FGoalName;
                            goals.FGoalQuestion = model.FGoalQuestion;
                        }
                        if (goals != null && model.FGoalName != null && goals.FGoalName == null)
                        {
                            goals.FGoalName = model.FGoalName;
                            goals.FGoalQuestion = model.FGoalQuestion;
                        }
                        if (goals == null && model.FGoalName != null)
                        {
                            user.Goals = new Goals
                            {
                                FGoalName = model.FGoalName,
                                FGoalQuestion = model.FGoalQuestion,
                            };
                        }
                        if (goals == null && model.FGoalName == null)
                        { }
                        _context.SaveChanges();
                        return PartialView("_FGoalWelcome", model);
                    };
                case "GGoal":
                    {
                        if (goals != null && model.GGoalName != null && goals.GGoalName != null)
                        {
                            goals.GGoalName = model.GGoalName;
                            goals.GGoalQuestion = model.GGoalQuestion;
                        }
                        if (goals != null && model.GGoalName == null && goals.GGoalName != null)
                        {
                            goals.GGoalName = model.GGoalName;
                            goals.GGoalQuestion = model.GGoalQuestion;
                        }
                        if (goals != null && model.GGoalName != null && goals.GGoalName == null)
                        {
                            goals.GGoalName = model.GGoalName;
                            goals.GGoalQuestion = model.GGoalQuestion;
                        }
                        if (goals == null && model.GGoalName != null)
                        {
                            user.Goals = new Models.Goals
                            {
                                GGoalName = model.GGoalName,
                                GGoalQuestion = model.GGoalQuestion,
                            };
                        }
                        if (goals == null && model.GGoalName == null)
                        { }
                        _context.SaveChanges();
                        return PartialView("_GGoalWelcome", model);
                    };
                case "HGoal":
                    {
                        if (goals != null && model.HGoalName != null && goals.HGoalName != null)
                        {
                            goals.HGoalName = model.HGoalName;
                            goals.HGoalQuestion = model.HGoalQuestion;
                        }
                        if (goals != null && model.HGoalName == null && goals.HGoalName != null)
                        {
                            goals.HGoalName = model.HGoalName;
                            goals.HGoalQuestion = model.HGoalQuestion;
                        }
                        if (goals != null && model.HGoalName != null && goals.HGoalName == null)
                        {
                            goals.HGoalName = model.HGoalName;
                            goals.HGoalQuestion = model.HGoalQuestion;
                        }
                        if (goals == null && model.HGoalName != null)
                        {
                            user.Goals = new Models.Goals
                            {
                                HGoalName = model.HGoalName,
                                HGoalQuestion = model.HGoalQuestion,
                            };
                        }
                        if (goals == null && model.HGoalName == null)
                        { }
                        _context.SaveChanges();
                        return PartialView("_HGoalWelcome", model);
                    };
                case "AGoalReset":
                    {
                        goals.AGoal1 = null;
                        goals.AGoal2 = null;
                        goals.AGoal3 = null;
                        goals.AGoal4 = null;
                        goals.AGoal5 = null;
                        goals.AGoal6 = null;
                        goals.AGoal7 = null;
                        goals.AGoalDate1 = null;
                        goals.AGoalDate2 = null;
                        goals.AGoalDate3 = null;
                        goals.AGoalDate4 = null;
                        goals.AGoalDate5 = null;
                        goals.AGoalDate6 = null;
                        goals.AGoalDate7 = null;
                        _context.SaveChanges();
                        return PartialView("_AGoalWelcome", model);
                    };
                case "BGoalReset":
                    {
                        goals.BGoal1 = null;
                        goals.BGoal2 = null;
                        goals.BGoal3 = null;
                        goals.BGoal4 = null;
                        goals.BGoal5 = null;
                        goals.BGoal6 = null;
                        goals.BGoal7 = null;
                        goals.BGoalDate1 = null;
                        goals.BGoalDate2 = null;
                        goals.BGoalDate3 = null;
                        goals.BGoalDate4 = null;
                        goals.BGoalDate5 = null;
                        goals.BGoalDate6 = null;
                        goals.BGoalDate7 = null;
                        _context.SaveChanges();
                        return PartialView("_BGoalWelcome", model);
                    };
                case "CGoalReset":
                    {
                        goals.CGoal1 = null;
                        goals.CGoal2 = null;
                        goals.CGoal3 = null;
                        goals.CGoal4 = null;
                        goals.CGoal5 = null;
                        goals.CGoal6 = null;
                        goals.CGoal7 = null;
                        goals.CGoalDate1 = null;
                        goals.CGoalDate2 = null;
                        goals.CGoalDate3 = null;
                        goals.CGoalDate4 = null;
                        goals.CGoalDate5 = null;
                        goals.CGoalDate6 = null;
                        goals.CGoalDate7 = null;
                        _context.SaveChanges();
                        return PartialView("_CGoalWelcome", model);
                    };
                case "DGoalReset":
                    {
                        goals.DGoal1 = null;
                        goals.DGoal2 = null;
                        goals.DGoal3 = null;
                        goals.DGoal4 = null;
                        goals.DGoal5 = null;
                        goals.DGoal6 = null;
                        goals.DGoal7 = null;
                        goals.DGoalDate1 = null;
                        goals.DGoalDate2 = null;
                        goals.DGoalDate3 = null;
                        goals.DGoalDate4 = null;
                        goals.DGoalDate5 = null;
                        goals.DGoalDate6 = null;
                        goals.DGoalDate7 = null;
                        _context.SaveChanges();
                        return PartialView("_DGoalWelcome", model);
                    };
                case "EGoalReset":
                    {
                        goals.EGoal1 = null;
                        goals.EGoal2 = null;
                        goals.EGoal3 = null;
                        goals.EGoal4 = null;
                        goals.EGoal5 = null;
                        goals.EGoal6 = null;
                        goals.EGoal7 = null;
                        goals.EGoalDate1 = null;
                        goals.EGoalDate2 = null;
                        goals.EGoalDate3 = null;
                        goals.EGoalDate4 = null;
                        goals.EGoalDate5 = null;
                        goals.EGoalDate6 = null;
                        goals.EGoalDate7 = null;
                        _context.SaveChanges();
                        return PartialView("_EGoalWelcome", model);
                    };
                case "FGoalReset":
                    {
                        goals.FGoal1 = null;
                        goals.FGoal2 = null;
                        goals.FGoal3 = null;
                        goals.FGoal4 = null;
                        goals.FGoal5 = null;
                        goals.FGoal6 = null;
                        goals.FGoal7 = null;
                        goals.FGoalDate1 = null;
                        goals.FGoalDate2 = null;
                        goals.FGoalDate3 = null;
                        goals.FGoalDate4 = null;
                        goals.FGoalDate5 = null;
                        goals.FGoalDate6 = null;
                        goals.FGoalDate7 = null;
                        _context.SaveChanges();
                        return PartialView("_FGoalWelcome", model);
                    };
                case "GGoalReset":
                    {
                        goals.GGoal1 = null;
                        goals.GGoal2 = null;
                        goals.GGoal3 = null;
                        goals.GGoal4 = null;
                        goals.GGoal5 = null;
                        goals.GGoal6 = null;
                        goals.GGoal7 = null;
                        goals.GGoalDate1 = null;
                        goals.GGoalDate2 = null;
                        goals.GGoalDate3 = null;
                        goals.GGoalDate4 = null;
                        goals.GGoalDate5 = null;
                        goals.GGoalDate6 = null;
                        goals.GGoalDate7 = null;
                        _context.SaveChanges();
                        return PartialView("_GGoalWelcome", model);
                    };
                case "HGoalReset":
                    {
                        goals.HGoal1 = null;
                        goals.HGoal2 = null;
                        goals.HGoal3 = null;
                        goals.HGoal4 = null;
                        goals.HGoal5 = null;
                        goals.HGoal6 = null;
                        goals.HGoal7 = null;
                        goals.HGoalDate1 = null;
                        goals.HGoalDate2 = null;
                        goals.HGoalDate3 = null;
                        goals.HGoalDate4 = null;
                        goals.HGoalDate5 = null;
                        goals.HGoalDate6 = null;
                        goals.HGoalDate7 = null;
                        _context.SaveChanges();
                        return PartialView("_HGoalWelcome", model);
                    };
                default:
                    return (View());
            };
        }
    }
}

