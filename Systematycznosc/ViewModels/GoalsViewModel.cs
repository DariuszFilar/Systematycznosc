using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class GoalsViewModel
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

        public GoalsViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public GoalsViewModel() { }

        public GoalsViewModel(Goals goals)
        {
            this.Id = goals.Id;
            this.GoalName = goals.GoalName;
            this.GoalDays = goals.GoalDays;
            this.GoalQuestion = goals.GoalQuestion;
            this.Goal1 = goals.Goal1;
            this.GoalDate1 = goals.GoalDate1;
            this.Goal2 = goals.Goal2;
            this.GoalDate2 = goals.GoalDate2;
            this.Goal3 = goals.Goal3;
            this.GoalDate3 = goals.GoalDate3;
            this.Goal4 = goals.Goal4;
            this.GoalDate4 = goals.GoalDate4;
            this.Goal5 = goals.Goal5;
            this.GoalDate5 = goals.GoalDate5;
            this.Goal6 = goals.Goal6;
            this.GoalDate6 = goals.GoalDate6;
            this.Goal7 = goals.Goal7;
            this.GoalDate7 = goals.GoalDate7;
        }
    }
}