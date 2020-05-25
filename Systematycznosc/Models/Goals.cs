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
        public string CGoalName { get; set; }
        public string DGoalName { get; set; }
        public string EGoalName { get; set; }
        public string FGoalName { get; set; }
        public string GGoalName { get; set; }
        public string HGoalName { get; set; }
        public string AGoalQuestion { get; set; }
        public string BGoalQuestion { get; set; }
        public string CGoalQuestion { get; set; }
        public string DGoalQuestion { get; set; }
        public string EGoalQuestion { get; set; }
        public string FGoalQuestion { get; set; }
        public string GGoalQuestion { get; set; }
        public string HGoalQuestion { get; set; }
        public string AGoalDays { get; set; }
        public string BGoalDays { get; set; }
        public string CGoalDays { get; set; }
        public string DGoalDays { get; set; }
        public string EGoalDays { get; set; }
        public string FGoalDays { get; set; }
        public string GGoalDays { get; set; }
        public string HGoalDays { get; set; }
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
        public string CGoal1 { get; set; }
        public string CGoal2 { get; set; }
        public string CGoal3 { get; set; }
        public string CGoal4 { get; set; }
        public string CGoal5 { get; set; }
        public string CGoal6 { get; set; }
        public string CGoal7 { get; set; }
        public string DGoal1 { get; set; }
        public string DGoal2 { get; set; }
        public string DGoal3 { get; set; }
        public string DGoal4 { get; set; }
        public string DGoal5 { get; set; }
        public string DGoal6 { get; set; }
        public string DGoal7 { get; set; }
        public string EGoal1 { get; set; }
        public string EGoal2 { get; set; }
        public string EGoal3 { get; set; }
        public string EGoal4 { get; set; }
        public string EGoal5 { get; set; }
        public string EGoal6 { get; set; }
        public string EGoal7 { get; set; }
        public string FGoal1 { get; set; }
        public string FGoal2 { get; set; }
        public string FGoal3 { get; set; }
        public string FGoal4 { get; set; }
        public string FGoal5 { get; set; }
        public string FGoal6 { get; set; }
        public string FGoal7 { get; set; }
        public string GGoal1 { get; set; }
        public string GGoal2 { get; set; }
        public string GGoal3 { get; set; }
        public string GGoal4 { get; set; }
        public string GGoal5 { get; set; }
        public string GGoal6 { get; set; }
        public string GGoal7 { get; set; }
        public string HGoal1 { get; set; }
        public string HGoal2 { get; set; }
        public string HGoal3 { get; set; }
        public string HGoal4 { get; set; }
        public string HGoal5 { get; set; }
        public string HGoal6 { get; set; }
        public string HGoal7 { get; set; }

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
        public DateTime? CGoalDate1 { get; set; }
        public DateTime? CGoalDate2 { get; set; }
        public DateTime? CGoalDate3 { get; set; }
        public DateTime? CGoalDate4 { get; set; }
        public DateTime? CGoalDate5 { get; set; }
        public DateTime? CGoalDate6 { get; set; }
        public DateTime? CGoalDate7 { get; set; }
        public DateTime? DGoalDate1 { get; set; }
        public DateTime? DGoalDate2 { get; set; }
        public DateTime? DGoalDate3 { get; set; }
        public DateTime? DGoalDate4 { get; set; }
        public DateTime? DGoalDate5 { get; set; }
        public DateTime? DGoalDate6 { get; set; }
        public DateTime? DGoalDate7 { get; set; }
        public DateTime? EGoalDate1 { get; set; }
        public DateTime? EGoalDate2 { get; set; }
        public DateTime? EGoalDate3 { get; set; }
        public DateTime? EGoalDate4 { get; set; }
        public DateTime? EGoalDate5 { get; set; }
        public DateTime? EGoalDate6 { get; set; }
        public DateTime? EGoalDate7 { get; set; }
        public DateTime? FGoalDate1 { get; set; }
        public DateTime? FGoalDate2 { get; set; }
        public DateTime? FGoalDate3 { get; set; }
        public DateTime? FGoalDate4 { get; set; }
        public DateTime? FGoalDate5 { get; set; }
        public DateTime? FGoalDate6 { get; set; }
        public DateTime? FGoalDate7 { get; set; }
        public DateTime? GGoalDate1 { get; set; }
        public DateTime? GGoalDate2 { get; set; }
        public DateTime? GGoalDate3 { get; set; }
        public DateTime? GGoalDate4 { get; set; }
        public DateTime? GGoalDate5 { get; set; }
        public DateTime? GGoalDate6 { get; set; }
        public DateTime? GGoalDate7 { get; set; }
        public DateTime? HGoalDate1 { get; set; }
        public DateTime? HGoalDate2 { get; set; }
        public DateTime? HGoalDate3 { get; set; }
        public DateTime? HGoalDate4 { get; set; }
        public DateTime? HGoalDate5 { get; set; }
        public DateTime? HGoalDate6 { get; set; }
        public DateTime? HGoalDate7 { get; set; }
    }
}