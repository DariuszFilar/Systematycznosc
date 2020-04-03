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
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Relationship1 { get; set; }
        public string Relationship2 { get; set; }
        public string Relationship3 { get; set; }
        public string Relationship4 { get; set; }
        public string Relationship5 { get; set; }
        public string Relationship6 { get; set; }
        public string Relationship7 { get; set; }
        public string Relationship8 { get; set; }
        public string Relationship9 { get; set; }
        public string Relationship10 { get; set; }
        public string Relationship11 { get; set; }

        public UserProfileViewModel UserProfileViewModel { get; set; }

        public RelationshipViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public RelationshipViewModel() { }

        public RelationshipViewModel(Relationship relationship)
        {
            this.Id = relationship.Id;
            this.Relationship1 = relationship.Relationship1;
            this.Relationship2 = relationship.Relationship2;
            this.Relationship3 = relationship.Relationship3;
            this.Relationship4 = relationship.Relationship4;
            this.Relationship5 = relationship.Relationship5;
            this.Relationship6 = relationship.Relationship6;
            this.Relationship7 = relationship.Relationship7;
            this.Relationship8 = relationship.Relationship8;
            this.Relationship9 = relationship.Relationship9;
            this.Relationship10 = relationship.Relationship10;
        }
    }
}