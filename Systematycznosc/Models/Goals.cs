using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class Goals
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
    }
}