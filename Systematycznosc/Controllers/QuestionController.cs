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
    public class QuestionController : Controller
    {
        // GET: Question
        private readonly SystematycznoscContext _context;
        public QuestionController() { _context = new SystematycznoscContext(); }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null)
            {
                QuestionViewModel model = new QuestionViewModel
                {
                    MorningQuestions = _context.MorningQuestions.Where(x => x.UserProfileId == userId).ToList(),
                    EveningQuestions = _context.EveningQuestions.Where(x => x.UserProfileId == userId).ToList()
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult Index(string morningQuestionValue, string eveningQuestionValue)
        {
            var userId = User.Identity.GetUserId();
            if (morningQuestionValue != null)
            {
                if (_context.MorningQuestions.Where(x => x.UserProfileId == userId).Count() < 12)
                {
                    var morningQuestion = new MorningQuestion
                    {
                        MorningQuestionId = _context.MorningQuestions.Count() + 1,
                        MorningQuestionValue = morningQuestionValue,
                        UserProfileId = userId
                    };
                    _context.MorningQuestions.Add(morningQuestion);
                }
            }
            if (eveningQuestionValue != null)
            {
                if (_context.EveningQuestions.Where(x => x.UserProfileId == userId).Count() < 12)
                {
                    var eveningQuestion = new EveningQuestion
                    {
                        EveningQuestionId = _context.EveningQuestions.Count() + 1,
                        EveningQuestionValue = eveningQuestionValue,
                        UserProfileId = userId
                    };
                    _context.EveningQuestions.Add(eveningQuestion);
                }
            }
            _context.SaveChanges();
            ModelState.Clear();

            QuestionViewModel model = new QuestionViewModel
            {
                MorningQuestions = _context.MorningQuestions.Where(x => x.UserProfileId == userId).ToList(),
                EveningQuestions = _context.EveningQuestions.Where(x => x.UserProfileId == userId).ToList()
            };

            if (morningQuestionValue != null)
                return PartialView("_MorningQuestionTable", model);
            if (eveningQuestionValue != null)
                return PartialView("_EveningQuestionTable", model);
            else
                return View();
        }

        [HttpGet]
        public ActionResult MorningQuestionEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var morningQuestions = _context.MorningQuestions.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                QuestionViewModel model = new QuestionViewModel(morningQuestions);
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult MorningQuestionEdit(QuestionViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var morningQuestions = _context.MorningQuestions.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.MorningQuestions == null)
            {
                return RedirectToAction("Index", "Credo");
            }

            else
            {
                morningQuestions = model.MorningQuestions;
                foreach (var morningQuestion in morningQuestions)
                {
                    _context.Entry(morningQuestion).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                model.MorningQuestions = morningQuestions.ToList();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EveningQuestionEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var eveningQuestions = _context.EveningQuestions.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                QuestionViewModel model = new QuestionViewModel(eveningQuestions);
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult EveningQuestionEdit(QuestionViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var eveningQuestions = _context.EveningQuestions.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.EveningQuestions == null)
            {
                return RedirectToAction("Index", "Credo");
            }

            else
            {
                eveningQuestions = model.EveningQuestions;
                foreach (var eveningQuestion in eveningQuestions)
                {
                    _context.Entry(eveningQuestion).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                model.EveningQuestions = eveningQuestions.ToList();
                return View(model);
            }
        }
    }
}
