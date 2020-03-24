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


        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var credo = _context.Credo.FirstOrDefault(x => x.Id == userId);
            var morningQuestions = _context.MorningQuestions.FirstOrDefault(x => x.Id == userId);
            var eveningQuestions = _context.EveningQuestions.FirstOrDefault(x => x.Id == userId);
            var todo = _context.Todo.FirstOrDefault(x => x.Id == userId);
            UserProfileViewModelWrapper wrapper = new UserProfileViewModelWrapper();

            if (userProfile != null)
            {
                if (credo == null) { wrapper.CredoViewModel = new CredoViewModel(); }
                else { CredoViewModel Credo = new CredoViewModel(credo); wrapper.CredoViewModel = Credo; }
                if (morningQuestions == null) { wrapper.MorningQuestionsViewModel = new MorningQuestionsViewModel(); }
                else { MorningQuestionsViewModel MorningQuestions = new MorningQuestionsViewModel(morningQuestions); wrapper.MorningQuestionsViewModel = MorningQuestions; }
                if (eveningQuestions == null) { wrapper.EveningQuestionsViewModel = new EveningQuestionsViewModel(); }
                else { EveningQuestionsViewModel EveningQuestions = new EveningQuestionsViewModel(eveningQuestions); wrapper.EveningQuestionsViewModel = EveningQuestions; }
                if (todo == null) { wrapper.TodoViewModel = new TodoViewModel(); }
                else { TodoViewModel Todo = new TodoViewModel(todo); wrapper.TodoViewModel = Todo; }
                UserProfileViewModel UserProfile = new UserProfileViewModel(userProfile);
                wrapper.UserProfileViewModel = UserProfile;
                return View(wrapper);
            }
            else { return RedirectToAction("Manage", "Profile"); }
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
                return View(wrapper);
            }
            else if (userProfile != null && eveningQuestions != null && morningQuestions == null)
            {
                QuestionsViewModelWrapper wrapper = new QuestionsViewModelWrapper();
                EveningQuestionsViewModel EveningQuestions = new EveningQuestionsViewModel(eveningQuestions);
                wrapper.EveningQuestionsViewModel = EveningQuestions;
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
        public ActionResult Goals()
        {
            return View();
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
    }
}
