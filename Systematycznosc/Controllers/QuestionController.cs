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
            var morningQuestions = _context.MorningQuestions.Where(x => x.UserProfileId == userId);
            var eveningQuestions = _context.EveningQuestions.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                QuestionViewModel model = new QuestionViewModel
                {
                    MorningQuestions = morningQuestions.ToList(),
                    EveningQuestions = eveningQuestions.ToList()
                };

                return View(model);
            }

            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult Index(string morningQuestionValue)
        {
            var userId = User.Identity.GetUserId();
            var credosAmount = _context.MorningQuestions.Where(x => x.UserProfileId == userId).Count();
            if (credosAmount < 12)
            {
                var morningQuestion = new MorningQuestion
                {
                    MorningQuestionId = _context.MorningQuestions.Count() + 1,
                    MorningQuestionValue = morningQuestionValue,
                    UserProfileId = userId
                };
                _context.MorningQuestions.Add(morningQuestion);
                _context.SaveChanges();

                ModelState.Clear();
                var morningQuestions = _context.MorningQuestions.Where(x => x.UserProfileId == userId);
                var eveningQuestions = _context.EveningQuestions.Where(x => x.UserProfileId == userId);
                QuestionViewModel model = new QuestionViewModel
                {
                    MorningQuestions = morningQuestions.ToList(),
                    EveningQuestions = eveningQuestions.ToList()
                };
                
                return PartialView("_AddMorningQuestion", model);
            }

            else
            {
                ModelState.Clear();
                var credos = _context.Credoes.Where(x => x.UserProfileId == userId);
                CredoViewModel model = new CredoViewModel(credos);
                return View(model);
            }
        }
    }
}