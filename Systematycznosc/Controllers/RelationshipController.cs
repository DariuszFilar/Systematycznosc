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
    public class RelationshipController : Controller
    {
        private readonly SystematycznoscContext _context;
        public RelationshipController() { _context = new SystematycznoscContext(); }
        // GET: Relationship
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var relationships = _context.Relationships.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                RelationshipViewModel model = new RelationshipViewModel(relationships);
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult Index(string relationshipValue)
        {
            var userId = User.Identity.GetUserId();
           
            if (_context.Relationships.Where(x => x.UserProfileId == userId).Count() < 12)
            {
                var relationship = new Relationship
                {
                    RelationshipId = _context.Relationships.Count() + 1,
                    RelationshipValue = relationshipValue,
                    UserProfileId = userId
                };
                _context.Relationships.Add(relationship);
                _context.SaveChanges();

                ModelState.Clear();
                var relationships = _context.Relationships.Where(x => x.UserProfileId == userId);
                RelationshipViewModel model = new RelationshipViewModel(relationships);
                return PartialView("_Addrelationship", model);
            }

            else
            {
                ModelState.Clear();
                var relationships = _context.Relationships.Where(x => x.UserProfileId == userId);
                RelationshipViewModel model = new RelationshipViewModel(relationships);
                return PartialView("_Addrelationship", model);
            }
        }

        [HttpGet]
        public ActionResult RelationshipEdit()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = _context.UserProfiles.FirstOrDefault(x => x.Id == userId);
            var relationships = _context.Relationships.Where(x => x.UserProfileId == userId);

            if (userProfile != null)
            {
                RelationshipViewModel model = new RelationshipViewModel(relationships);
                return View(model);
            }
            else
            {
                return RedirectToAction("Manage", "Profile");
            }
        }

        [HttpPost]
        public ActionResult RelationshipEdit(RelationshipViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var relationships = _context.Relationships.AsNoTracking().Where(x => x.UserProfileId == userId).ToList();

            if (model.Relationships == null)
            {
                return RedirectToAction("Index", "relationship");
            }

            else
            {
                relationships = model.Relationships;
                foreach (var relationship in relationships)
                {
                    _context.Entry(relationship).State = EntityState.Modified;
                }

                _context.SaveChanges();
                ModelState.Clear();

                model.Relationships = relationships.ToList();
                return View(model);
            }
        }
    }
}