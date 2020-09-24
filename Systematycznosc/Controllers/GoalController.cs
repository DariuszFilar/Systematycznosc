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
                    SecondGoals = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToList(),
                    ThirdGoals = _context.ThirdGoals.Where(x => x.UserProfileId == userId).ToList(),
                    FourthGoals = _context.FourthGoals.Where(x => x.UserProfileId == userId).ToList(),
                    FifthGoals = _context.FifthGoals.Where(x => x.UserProfileId == userId).ToList(),
                    SixthGoals = _context.SixthGoals.Where(x => x.UserProfileId == userId).ToList(),
                    SeventhGoals = _context.SeventhGoals.Where(x => x.UserProfileId == userId).ToList(),
                    EightGoals = _context.EighthGoals.Where(x => x.UserProfileId == userId).ToList()
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
            string newGoal = "";


            if (saveButton == "newGoal")
            {
                if (_context.FirstGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = "firstGoal"; }
                if (_context.FirstGoals.Where(x => x.UserProfileId == userId).ToList().Count() != 0 && _context.SecondGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = "secondGoal"; }
                if (_context.SecondGoals.Where(x => x.UserProfileId == userId).ToList().Count() != 0 && _context.ThirdGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = "thirdGoal"; }
                if (_context.ThirdGoals.Where(x => x.UserProfileId == userId).ToList().Count() != 0 && _context.FourthGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = "fourthGoal"; }
                if (_context.FourthGoals.Where(x => x.UserProfileId == userId).ToList().Count() != 0 && _context.FifthGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = "fifthGoal"; }
                if (_context.FifthGoals.Where(x => x.UserProfileId == userId).ToList().Count() != 0 && _context.SixthGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = "sixthGoal"; }
                if (_context.SixthGoals.Where(x => x.UserProfileId == userId).ToList().Count() != 0 && _context.SeventhGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = "seventhGoal"; }
                if (_context.SeventhGoals.Where(x => x.UserProfileId == userId).ToList().Count() != 0 && _context.EighthGoals.Where(x => x.UserProfileId == userId).ToList().Count() == 0) { newGoal = "eightGoal"; }
                if (newGoal == "firstGoal")
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

                if (newGoal == "secondGoal")
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

                if (newGoal == "thirdGoal")
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var thirdGoal = new ThirdGoal
                        {
                            GoalId = i,
                            GoalName = goalName,
                            GoalQuestion = goalQuestion,
                            UserProfileId = userId
                        };

                        _context.ThirdGoals.Add(thirdGoal);
                        _context.SaveChanges();
                    }
                }
                if (newGoal == "fourthGoal")
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var fourthGoal = new FourthGoal
                        {
                            GoalId = i,
                            GoalName = goalName,
                            GoalQuestion = goalQuestion,
                            UserProfileId = userId
                        };

                        _context.FourthGoals.Add(fourthGoal);
                        _context.SaveChanges();
                    }
                }

                if (newGoal == "fifthGoal")
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var fifthGoal = new FifthGoal
                        {
                            GoalId = i,
                            GoalName = goalName,
                            GoalQuestion = goalQuestion,
                            UserProfileId = userId
                        };

                        _context.FifthGoals.Add(fifthGoal);
                        _context.SaveChanges();
                    }
                }
                if (newGoal == "sixthGoal")
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var sixthGoal = new SixthGoal
                        {
                            GoalId = i,
                            GoalName = goalName,
                            GoalQuestion = goalQuestion,
                            UserProfileId = userId
                        };

                        _context.SixthGoals.Add(sixthGoal);
                        _context.SaveChanges();
                    }
                }

                if (newGoal == "seventhGoal")
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var seventhGoal = new SeventhGoal
                        {
                            GoalId = i,
                            GoalName = goalName,
                            GoalQuestion = goalQuestion,
                            UserProfileId = userId
                        };

                        _context.SeventhGoals.Add(seventhGoal);
                        _context.SaveChanges();
                    }
                }

                if (newGoal == "eightGoal")
                {
                    for (int i = 1; i < 8; i++)
                    {
                        var eightGoal = new EightGoal
                        {
                            GoalId = i,
                            GoalName = goalName,
                            GoalQuestion = goalQuestion,
                            UserProfileId = userId
                        };

                        _context.EighthGoals.Add(eightGoal);
                        _context.SaveChanges();
                    }
                }
                model.FirstGoals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToList();
                model.SecondGoals = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToList();
                model.ThirdGoals = _context.ThirdGoals.Where(x => x.UserProfileId == userId).ToList();
                model.FourthGoals = _context.FourthGoals.Where(x => x.UserProfileId == userId).ToList();
                model.FifthGoals = _context.FifthGoals.Where(x => x.UserProfileId == userId).ToList();
                model.SixthGoals = _context.SixthGoals.Where(x => x.UserProfileId == userId).ToList();
                model.SeventhGoals = _context.SeventhGoals.Where(x => x.UserProfileId == userId).ToList();
                model.EightGoals = _context.EighthGoals.Where(x => x.UserProfileId == userId).ToList();

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
                    case "thirdGoal":
                        goals = _context.ThirdGoals.Where(x => x.UserProfileId == userId).ToArray();
                        renderPartial = "_ThirdGoalTable";
                        break;
                    case "fourthGoal":
                        goals = _context.FourthGoals.Where(x => x.UserProfileId == userId).ToArray();
                        renderPartial = "_FourthGoalTable";
                        break;
                    case "fifthGoal":
                        goals = _context.FifthGoals.Where(x => x.UserProfileId == userId).ToArray();
                        renderPartial = "_FifthGoalTable";
                        break;
                    case "sixthGoal":
                        goals = _context.SixthGoals.Where(x => x.UserProfileId == userId).ToArray();
                        renderPartial = "_SixthGoalTable";
                        break;
                    case "seventhGoal":
                        goals = _context.SeventhGoals.Where(x => x.UserProfileId == userId).ToArray();
                        renderPartial = "_SeventhGoalTable";
                        break;
                    case "eightGoal":
                        goals = _context.EighthGoals.Where(x => x.UserProfileId == userId).ToArray();
                        renderPartial = "_EightGoalTable";
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

        [HttpGet]
        public ActionResult GoalEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null)
            {
                GoalViewModel model = new GoalViewModel
                {
                    FirstGoals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToList(),
                    SecondGoals = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToList(),
                    ThirdGoals = _context.ThirdGoals.Where(x => x.UserProfileId == userId).ToList(),
                    FourthGoals = _context.FourthGoals.Where(x => x.UserProfileId == userId).ToList(),
                    FifthGoals = _context.FifthGoals.Where(x => x.UserProfileId == userId).ToList(),
                    SixthGoals = _context.SixthGoals.Where(x => x.UserProfileId == userId).ToList(),
                    SeventhGoals = _context.SeventhGoals.Where(x => x.UserProfileId == userId).ToList(),
                    EightGoals = _context.EighthGoals.Where(x => x.UserProfileId == userId).ToList()
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult GoalEdit(GoalViewModel model, string saveButton)
        {
            var userId = User.Identity.GetUserId();

            if (saveButton == "firstGoal")
            {
               var goal = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToArray();
                goal[0].GoalName = model.FirstGoals[0].GoalName;
                goal[0].GoalQuestion = model.FirstGoals[0].GoalName;
            }

            if (saveButton == "secondGoal")
            {
                var goal = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToArray();
                goal[0].GoalName = model.SecondGoals[0].GoalName;
                goal[0].GoalQuestion = model.SecondGoals[0].GoalName;
            }
            if (saveButton == "thirdGoal")
            {
                var goal = _context.ThirdGoals.Where(x => x.UserProfileId == userId).ToArray();
                goal[0].GoalName = model.ThirdGoals[0].GoalName;
                goal[0].GoalQuestion = model.ThirdGoals[0].GoalName;
            }
            if (saveButton == "fourthGoal")
            {
                var goal = _context.FourthGoals.Where(x => x.UserProfileId == userId).ToArray();
                goal[0].GoalName = model.FourthGoals[0].GoalName;
                goal[0].GoalQuestion = model.FourthGoals[0].GoalName;
            }
            if (saveButton == "fifthGoal")
            {
                var goal = _context.FifthGoals.Where(x => x.UserProfileId == userId).ToArray();
                goal[0].GoalName = model.FifthGoals[0].GoalName;
                goal[0].GoalQuestion = model.FifthGoals[0].GoalName;
            }
            if (saveButton == "sixthGoal")
            {
                var goal = _context.SixthGoals.Where(x => x.UserProfileId == userId).ToArray();
                goal[0].GoalName = model.SixthGoals[0].GoalName;
                goal[0].GoalQuestion = model.SixthGoals[0].GoalName;
            }
            if (saveButton == "seventGoal")
            {
                var goal = _context.SeventhGoals.Where(x => x.UserProfileId == userId).ToArray();
                goal[0].GoalName = model.SeventhGoals[0].GoalName;
                goal[0].GoalQuestion = model.SeventhGoals[0].GoalName;
            }
            if (saveButton == "eightGoal")
            {
                var goal = _context.EighthGoals.Where(x => x.UserProfileId == userId).ToArray();
                goal[0].GoalName = model.EightGoals[0].GoalName;
                goal[0].GoalQuestion = model.EightGoals[0].GoalName;
            }

            model.FirstGoals = _context.FirstGoals.Where(x => x.UserProfileId == userId).ToList();
            model.SecondGoals = _context.SecondGoals.Where(x => x.UserProfileId == userId).ToList();
            model.ThirdGoals = _context.ThirdGoals.Where(x => x.UserProfileId == userId).ToList();
            model.FourthGoals = _context.FourthGoals.Where(x => x.UserProfileId == userId).ToList();
            model.FifthGoals = _context.FifthGoals.Where(x => x.UserProfileId == userId).ToList();
            model.SixthGoals = _context.SixthGoals.Where(x => x.UserProfileId == userId).ToList();
            model.SeventhGoals = _context.SeventhGoals.Where(x => x.UserProfileId == userId).ToList();
            model.EightGoals = _context.EighthGoals.Where(x => x.UserProfileId == userId).ToList();

            _context.SaveChanges();
            //ModelState.Clear();
            return View(model);
        }
    }
}

