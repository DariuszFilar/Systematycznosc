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
        public ActionResult Index(GoalViewModel model, string saveButton, string status, string goalName, string goalQuestion)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            int newGoal = 1;


            if (saveButton == "newGoal")
            {
                if (_context.FirstGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = 1; }
                if (_context.SecondGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = 2; }

                if (newGoal == 1)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var firstGoal = new FirstGoal
                        {
                            GoalId = i,
                            GoalName = goalName,
                            GoalQuestion = goalQuestion,
                            UserProfileId = userId
                        };

                        _context.FirstGoals.Add(firstGoal);
                        _context.SaveChanges();
                    }
                }

                if (newGoal == 2)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var secondGoal = new SecondGoal
                        {
                            GoalId = i,
                            GoalName = goalName,
                            GoalQuestion = goalQuestion,
                            UserProfileId = userId
                        };

                        _context.SecondGoals.Add(secondGoal);
                        _context.SaveChanges();
                    }
                }


                model.FirstGoals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToList();
                model.SecondGoals = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToList();

                return View(model);
            }
            else
            {
                dynamic goals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToArray();
                string renderPartial = "";
                if (user == null)
                    return View();

                switch (saveButton)
                {
                    case "firstGoal":
                        goals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToArray();
                        renderPartial = "_FirstGoalTable";
                        break;
                    case "secondGoal":
                        goals = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToArray();
                        renderPartial = "_SecondGoalTable";
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
                return PartialView(renderPartial, model);
            }
        }
    }
}

