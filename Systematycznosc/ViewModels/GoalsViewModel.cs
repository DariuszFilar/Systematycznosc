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
        public string AGoalName { get; set; }
        public string BGoalName { get; set; }
        public string AGoalQuestion { get; set; }
        public string BGoalQuestion { get; set; }
        public string AGoalDays { get; set; }
        public string BGoalDays { get; set; }
        public string AGoal1 { get; set; }
        public string AGoal2 { get; set; }
        public string AGoal3 { get; set; }
        public string AGoal4 { get; set; }
        public string AGoal5 { get; set; }
        public string AGoal6 { get; set; }
        public string AGoal7 { get; set; }
        public string BGoal1 { get; set; }
        public string BGoal2 { get; set; }
        public string BGoal3 { get; set; }
        public string BGoal4 { get; set; }
        public string BGoal5 { get; set; }
        public string BGoal6 { get; set; }
        public string BGoal7 { get; set; }

        public DateTime? AGoalDate1 { get; set; }
        public DateTime? AGoalDate2 { get; set; }
        public DateTime? AGoalDate3 { get; set; }
        public DateTime? AGoalDate4 { get; set; }
        public DateTime? AGoalDate5 { get; set; }
        public DateTime? AGoalDate6 { get; set; }
        public DateTime? AGoalDate7 { get; set; }
        public DateTime? BGoalDate1 { get; set; }
        public DateTime? BGoalDate2 { get; set; }
        public DateTime? BGoalDate3 { get; set; }
        public DateTime? BGoalDate4 { get; set; }
        public DateTime? BGoalDate5 { get; set; }
        public DateTime? BGoalDate6 { get; set; }
        public DateTime? BGoalDate7 { get; set; }

        public UserProfileViewModel UserProfileViewModel { get; set; }

        public GoalsViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public GoalsViewModel() { }

        public GoalsViewModel(Goals goals)
        {
            this.Id = goals.Id;
            this.AGoalName = goals.AGoalName;
            this.AGoalDays = goals.AGoalDays;
            this.AGoalQuestion = goals.AGoalQuestion;
            this.AGoal1 = goals.AGoal1;
            this.AGoalDate1 = goals.AGoalDate1;
            this.AGoal2 = goals.AGoal2;
            this.AGoalDate2 = goals.AGoalDate2;
            this.AGoal3 = goals.AGoal3;
            this.AGoalDate3 = goals.AGoalDate3;
            this.AGoal4 = goals.AGoal4;
            this.AGoalDate4 = goals.AGoalDate4;
            this.AGoal5 = goals.AGoal5;
            this.AGoalDate5 = goals.AGoalDate5;
            this.AGoal6 = goals.AGoal6;
            this.AGoalDate6 = goals.AGoalDate6;
            this.AGoal7 = goals.AGoal7;
            this.AGoalDate7 = goals.AGoalDate7;
            this.BGoalName = goals.BGoalName;
            this.BGoalDays = goals.BGoalDays;
            this.BGoalQuestion = goals.BGoalQuestion;
            this.BGoal1 = goals.BGoal1;
            this.BGoalDate1 = goals.BGoalDate1;
            this.BGoal2 = goals.BGoal2;
            this.BGoalDate2 = goals.BGoalDate2;
            this.BGoal3 = goals.BGoal3;
            this.BGoalDate3 = goals.BGoalDate3;
            this.BGoal4 = goals.BGoal4;
            this.BGoalDate4 = goals.BGoalDate4;
            this.BGoal5 = goals.BGoal5;
            this.BGoalDate5 = goals.BGoalDate5;
            this.BGoal6 = goals.BGoal6;
            this.BGoalDate6 = goals.BGoalDate6;
            this.BGoal7 = goals.BGoal7;
            this.BGoalDate7 = goals.BGoalDate7;
        }
    }
}