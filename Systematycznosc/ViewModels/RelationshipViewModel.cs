using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class RelationshipViewModel
    {
        public virtual ApplicationUser User { get; set; }

        public List<Relationship> Relationships { get; set; }

        public RelationshipViewModel(IEnumerable<Relationship> relationships)
        {
            Relationships = relationships.ToList();
        }

        public RelationshipViewModel()
        {
        }
    }
}