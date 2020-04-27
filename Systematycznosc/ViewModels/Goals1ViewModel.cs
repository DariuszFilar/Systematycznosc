using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class Goals1ViewModel
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string GoalName { get; set; }
        public string GoalQuestion { get; set; }
        public string GoalDays { get; set; }
        public string Goal1 { get; set; }
        public string Goal2 { get; set; }
        public string Goal3 { get; set; }
        public string Goal4 { get; set; }
        public string Goal5 { get; set; }
        public string Goal6 { get; set; }
        public string Goal7 { get; set; }

        public DateTime? GoalDate1 { get; set; }
        public DateTime? GoalDate2 { get; set; }
        public DateTime? GoalDate3 { get; set; }
        public DateTime? GoalDate4 { get; set; }
        public DateTime? GoalDate5 { get; set; }
        public DateTime? GoalDate6 { get; set; }
        public DateTime? GoalDate7 { get; set; }

        public UserProfileViewModel UserProfileViewModel { get; set; }

        public Goals1ViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public Goals1ViewModel() { }

        public Goals1ViewModel(Goals1 goals1)
        {
            this.Id = goals1.Id;
            this.GoalName = goals1.GoalName;
            this.GoalDays = goals1.GoalDays;
            this.GoalQuestion = goals1.GoalQuestion;
            this.Goal1 = goals1.Goal1;
            this.GoalDate1 = goals1.GoalDate1;
            this.Goal2 = goals1.Goal2;
            this.GoalDate2 = goals1.GoalDate2;
            this.Goal3 = goals1.Goal3;
            this.GoalDate3 = goals1.GoalDate3;
            this.Goal4 = goals1.Goal4;
            this.GoalDate4 = goals1.GoalDate4;
            this.Goal5 = goals1.Goal5;
            this.GoalDate5 = goals1.GoalDate5;
            this.Goal6 = goals1.Goal6;
            this.GoalDate6 = goals1.GoalDate6;
            this.Goal7 = goals1.Goal7;
            this.GoalDate7 = goals1.GoalDate7;
        }
    }
}