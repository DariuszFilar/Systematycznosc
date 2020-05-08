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
    }
}