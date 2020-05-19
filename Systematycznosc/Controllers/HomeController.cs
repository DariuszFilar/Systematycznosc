using Microsoft.AspNet.Identity;
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
        private readonly SystematycznoscContext _context;

        public HomeController() { _context = new SystematycznoscContext(); }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var credo = _context.Credo.FirstOrDefault(x => x.Id == userId);
            var morningQuestions = _context.MorningQuestions.FirstOrDefault(x => x.Id == userId);
            var eveningQuestions = _context.EveningQuestions.FirstOrDefault(x => x.Id == userId);
            var todo = _context.Todo.FirstOrDefault(x => x.Id == userId);
            var familyBirthday = _context.FamilyBirthday.FirstOrDefault(x => x.Id == userId);
            var friendsBirthday = _context.FriendsBirthday.FirstOrDefault(x => x.Id == userId);
            var othersBirthday = _context.OthersBirthday.FirstOrDefault(x => x.Id == userId);
            var relationship = _context.Relationship.FirstOrDefault(x => x.Id == userId);
            var goals = _context.Goals.FirstOrDefault(x => x.Id == userId);
            UserProfileViewModelWrapper wrapper = new UserProfileViewModelWrapper();

            if (userProfile != null)
            {
                if (credo == null) { wrapper.CredoViewModel = new CredoViewModel(); }
                else { CredoViewModel Credo = new CredoViewModel(credo); wrapper.CredoViewModel = Credo; }
                if (morningQuestions == null) { wrapper.MorningQuestionsViewModel = new MorningQuestionsViewModel(); }
                else { MorningQuestionsViewModel MorningQuestions = new MorningQuestionsViewModel(morningQuestions); wrapper.MorningQuestionsViewModel = MorningQuestions; }
                if (eveningQuestions == null) { wrapper.EveningQuestionsViewModel = new EveningQuestionsViewModel(); }
                else
                {
                    EveningQuestionsViewModel EveningQuestions = new EveningQuestionsViewModel(eveningQuestions);
                    wrapper.EveningQuestionsViewModel = EveningQuestions;
                }
                if (todo == null) { wrapper.TodoViewModel = new TodoViewModel(); }
                else { TodoViewModel Todo = new TodoViewModel(todo); wrapper.TodoViewModel = Todo; }
                UserProfileViewModel UserProfile = new UserProfileViewModel(userProfile);
                wrapper.UserProfileViewModel = UserProfile;
                if (familyBirthday == null) { wrapper.FamilyBirthdayViewModel = new FamilyBirthdayViewModel(); }
                else { FamilyBirthdayViewModel FamilyBirthday = new FamilyBirthdayViewModel(familyBirthday); wrapper.FamilyBirthdayViewModel = FamilyBirthday; }
                if (friendsBirthday == null) { wrapper.FriendsBirthdayViewModel = new FriendsBirthdayViewModel(); }
                else { FriendsBirthdayViewModel FriendsBirthday = new FriendsBirthdayViewModel(friendsBirthday); wrapper.FriendsBirthdayViewModel = FriendsBirthday; }
                if (othersBirthday == null) { wrapper.OthersBirthdayViewModel = new OthersBirthdayViewModel(); }
                else { OthersBirthdayViewModel OthersBirthday = new OthersBirthdayViewModel(othersBirthday); wrapper.OthersBirthdayViewModel = OthersBirthday; }
                if (relationship == null) { wrapper.RelationshipViewModel = new RelationshipViewModel(); }
                else { RelationshipViewModel Relationship = new RelationshipViewModel(relationship); wrapper.RelationshipViewModel = Relationship; }
                if (goals == null) { wrapper.GoalsViewModel = new GoalsViewModel(); }
                else { GoalsViewModel Goals = new GoalsViewModel(goals); wrapper.GoalsViewModel = Goals; }
                return View(wrapper);

            }
            else { return RedirectToAction("Manage", "Profile"); }
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
                        if (goals.AGoalDate1 != null && goals.AGoalDate1 == DateTime.Today)
                        {
                            goals.AGoalDate1 = DateTime.Today;
                            goals.AGoal1 = model.GoalsViewModel.AGoal1;
                            model.GoalsViewModel.AGoalDate1 = goals.AGoalDate1;
                            model.GoalsViewModel.AGoal1 = goals.AGoal1;
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
                            goals.AGoalDate6 == null && goals.AGoalDate1 != DateTime.Today)
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
                            goals.BGoalDate6 == null && goals.BGoalDate1 != DateTime.Today)
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

                default:
                    return PartialView("_BGoalTable", model);
            }
        }

    

        public ActionResult Credo()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var credo = _context.Credo.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null && credo != null)
            {
                CredoViewModel model = new CredoViewModel(credo);
                return View(model);
            }
            else if (userProfile != null && credo == null)
            {
                CredoViewModel model = new CredoViewModel();
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
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var credo = _context.Credo.FirstOrDefault(x => x.Id == userId);

            if (credo != null)
            {
                CredoViewModel model = new CredoViewModel(credo);
                return View(model);

            }
            else
            {
                CredoViewModel model = new CredoViewModel();
                return View(model);

            }

        }
        [HttpPost]
        public ActionResult CredoEdit(CredoViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var credo = _context.Credo.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return View();

            if (credo != null)
            {
                credo.Credo1 = model.Credo1;
                credo.Credo2 = model.Credo2;
                credo.Credo3 = model.Credo3;
                credo.Credo4 = model.Credo4;
                credo.Credo5 = model.Credo5;
                credo.Credo6 = model.Credo6;
                credo.Credo7 = model.Credo7;
                credo.Credo8 = model.Credo8;
                credo.Credo9 = model.Credo9;
                credo.Credo10 = model.Credo10;
            }
            else
            {
                user.Credo = new Models.Credo
                {
                    Credo1 = model.Credo1,
                    Credo2 = model.Credo2,
                    Credo3 = model.Credo3,
                    Credo4 = model.Credo4,
                    Credo5 = model.Credo5,
                    Credo6 = model.Credo6,
                    Credo7 = model.Credo7,
                    Credo8 = model.Credo8,
                    Credo9 = model.Credo9,
                    Credo10 = model.Credo10
                };
            }
            _context.SaveChanges();
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
                QuestionsViewModelWrapper wrapper = new QuestionsViewModelWrapper();
                wrapper.MorningQuestionsViewModel = new MorningQuestionsViewModel();
                wrapper.EveningQuestionsViewModel = new EveningQuestionsViewModel();
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
                user.MorningQuestions = new Models.MorningQuestions
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
                    Todo10 = model.Todo10
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
                            goals.AGoalDate6 == null && goals.AGoalDate1 != DateTime.Today)
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
                            goals.BGoalDate6 == null && goals.BGoalDate1 != DateTime.Today)
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
                default:
                    return (View());
            };
        }
    }
}

