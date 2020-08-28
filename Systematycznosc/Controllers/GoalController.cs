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
    public class GoalController : Controller
    {
        // GET: Goal
        private readonly SystematycznoscContext _context;
        public GoalController() { _context = new SystematycznoscContext(); }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null)
            {
                GoalViewModel model = new GoalViewModel
                {
                    FirstGoals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToList(),
                    SecondGoals = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToList()
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult Index(GoalViewModel model, string saveButton, string status)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            dynamic goals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToArray();

            if (user == null)
                return View();
                       
            switch(saveButton)
            {
                case "firstGoal":
                     goals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToArray();
                    break;
                case "secondGoal":
                     goals = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToArray();
                    break;                    
            }

            //Dla tych samych dat
            if (goals[0].GoalDate == null)
            {
                goals[0].GoalDate = DateTime.Today;
                goals[0].GoalStatus = status;
            }
            if (goals[0].GoalDate != null && goals[0].GoalDate == DateTime.Today)
            {
                goals[0].GoalDate = DateTime.Today;
                goals[0].GoalStatus = status;
            }
            if (goals[1].GoalDate != null && goals[1].GoalDate == DateTime.Today)
            {
                goals[1].GoalDate = DateTime.Today;
                goals[1].GoalStatus = status;
            }
            if (goals[2].GoalDate != null && goals[2].GoalDate == DateTime.Today)
            {
                goals[2].GoalDate = DateTime.Today;
                goals[2].GoalStatus = status;
            }
            if (goals[3].GoalDate != null && goals[3].GoalDate == DateTime.Today)
            {
                goals[3].GoalDate = DateTime.Today;
                goals[3].GoalStatus = status;
            }
            if (goals[4].GoalDate != null && goals[4].GoalDate == DateTime.Today)
            {
                goals[4].GoalDate = DateTime.Today;
                goals[4].GoalStatus = status;
            }
            if (goals[5].GoalDate != null && goals[5].GoalDate == DateTime.Today)
            {
                goals[5].GoalDate = DateTime.Today;
                goals[5].GoalStatus = status;
            }
            if (goals[6].GoalDate != null && goals[6].GoalDate == DateTime.Today)
            {
                goals[6].GoalDate = DateTime.Today;
                goals[6].GoalStatus = status;
            }
            //Dla wolnych miejsc

            if (goals[0].GoalDate != null && goals[1].GoalDate == null && goals[0].GoalDate != DateTime.Today)
            {
                goals[1].GoalDate = DateTime.Today;
                goals[1].GoalStatus = status;
            }

            else if (goals[0].GoalDate != null && goals[1].GoalDate != null && goals[2].GoalDate == null && goals[1].GoalDate != DateTime.Today)
            {
                goals[2].GoalDate = DateTime.Today;
                goals[2].GoalStatus = status;
            }
            else if (goals[0].GoalDate != null && goals[1].GoalDate != null && goals[2].GoalDate != null && goals[3].GoalDate == null && goals[2].GoalDate != DateTime.Today)
            {
                goals[3].GoalDate = DateTime.Today;
                goals[3].GoalStatus = status;
            }
            else if (goals[0].GoalDate != null && goals[1].GoalDate != null && goals[2].GoalDate != null && goals[3].GoalDate != null && goals[4].GoalDate == null && goals[3].GoalDate != DateTime.Today)
            {
                goals[4].GoalDate = DateTime.Today;
                goals[4].GoalStatus = status;
            }

            if (goals[0].GoalDate != null && goals[1].GoalDate != null && goals[2].GoalDate != null && goals[3].GoalDate != null && goals[4].GoalDate != null && goals[5].GoalDate == null && goals[4].GoalDate != DateTime.Today)
            {
                goals[5].GoalDate = DateTime.Today;
                goals[5].GoalStatus = status;
            }

            if (goals[0].GoalDate != null && goals[1].GoalDate != null && goals[2].GoalDate != null && goals[3].GoalDate != null && goals[4].GoalDate != null && goals[5].GoalDate != null &&
           goals[6].GoalDate == null && goals[5].GoalDate != DateTime.Today)
            {
                goals[5].GoalDate = DateTime.Today;
                goals[5].GoalStatus = status;
            }

            //Dla zajętych
            if (goals[6].GoalDate != null && goals[6].GoalDate != DateTime.Today)
            {
                goals[0].GoalStatus = goals[1].GoalStatus;
                goals[0].GoalDate = goals[1].GoalDate;
                goals[1].GoalStatus = goals[2].GoalStatus;
                goals[1].GoalDate = goals[2].GoalDate;
                goals[2].GoalStatus = goals[3].GoalStatus;
                goals[2].GoalDate = goals[3].GoalDate;
                goals[3].GoalStatus = goals[4].GoalStatus;
                goals[3].GoalDate = goals[4].GoalDate;
                goals[4].GoalStatus = goals[5].GoalStatus;
                goals[4].GoalDate = goals[5].GoalDate;
                goals[5].GoalStatus = goals[6].GoalStatus;
                goals[5].GoalDate = goals[6].GoalDate;
                goals[6].GoalStatus = status;
                goals[6].GoalDate = DateTime.Today;
            }

            model = new GoalViewModel(goals);
            _context.SaveChanges();
            return PartialView("_FirstGoalTable", model);
        }
    }
}

