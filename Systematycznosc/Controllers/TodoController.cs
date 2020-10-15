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
    public class TodoController : Controller
    {
        // GET: Credo
        private readonly SystematycznoscContext _context;
        public TodoController() { _context = new SystematycznoscContext(); }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);

            if (userProfile != null)
            {
                TodoViewModel model = new TodoViewModel
                {
                    Todoes = _context.Todoes.Where(x => x.UserProfileId == userId).ToList(),
                    ImportantEvents = _context.ImportantEvents.Where(x => x.UserProfileId == userId).ToList()
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult Index(string todoValue, string importantEventName, DateTime? importantEventDate)
        {
            var userId = User.Identity.GetUserId();

            if (todoValue != null)
            {
                if (_context.Todoes.Where(x => x.UserProfileId == userId).Count() < 16)
                {
                    var todo = new Todo
                    {
                        TodoId = _context.Todoes.Count() + 1,
                        TodoValue = todoValue,
                        UserProfileId = userId
                    };
                    _context.Todoes.Add(todo);
                }
            }

            if (importantEventName != null && importantEventDate != null)
            {
                if (_context.ImportantEvents.Where(x => x.UserProfileId == userId).Count() < 16)
                {
                    var importantEvent = new ImportantEvent
                    {
                        ImportantEventId = _context.ImportantEvents.Count() + 1,
                        ImportantEventName = importantEventName,
                        ImportantEventDate = importantEventDate,
                        UserProfileId = userId
                    };
                    _context.ImportantEvents.Add(importantEvent);
                }
            }

            _context.SaveChanges();
            ModelState.Clear();

            TodoViewModel model = new TodoViewModel
            {
                Todoes = _context.Todoes.Where(x => x.UserProfileId == userId).ToList(),
                ImportantEvents = _context.ImportantEvents.Where(x => x.UserProfileId == userId).ToList()
            };

            if (todoValue != null)
                return PartialView("_TodoTable", model);
            if (importantEventName != null && importantEventDate != null)
                return PartialView("_ImportantEventTable", model);
            else
                return View();
        }

        [HttpGet]
        public ActionResult TodoEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var todoes = _context.Todoes.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                TodoViewModel model = new TodoViewModel(todoes);
                return View(model);
            }

            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult TodoEdit(TodoViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var todoes = _context.Todoes.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.Todoes == null)
            {
                return RedirectToAction("Index", "Todo");
            }

            else
            {
                todoes = model.Todoes;
                foreach (var todo in todoes)
                {
                    _context.Entry(todo).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                model.Todoes = todoes.ToList();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult ImportantEventEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var importantEvents = _context.ImportantEvents.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                TodoViewModel model = new TodoViewModel(importantEvents);
                return View(model);
            }

            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult ImportantEventEdit(TodoViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var imporantEvents = _context.ImportantEvents.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.ImportantEvents == null)
            {
                return RedirectToAction("Index", "Todo");
            }

            else
            {
                imporantEvents = model.ImportantEvents;
                foreach (var imporantEvent in imporantEvents)
                {
                    if (imporantEvent.ImportantEventName == null)
                    {
                        imporantEvent.ImportantEventDate = null;
                    }
                    _context.Entry(imporantEvent).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                return View(model);
            }
        }
    }
}