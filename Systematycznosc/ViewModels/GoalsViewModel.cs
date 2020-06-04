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

        public UserProfileViewModel UserProfileViewModel { get; set; }

        public GoalsViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public GoalsViewModel() { }

        public GoalsViewModel(Goals goals)
        {
            if (goals != null)
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
                this.CGoalName = goals.CGoalName;
                this.CGoalDays = goals.CGoalDays;
                this.CGoalQuestion = goals.CGoalQuestion;
                this.CGoal1 = goals.CGoal1;
                this.CGoalDate1 = goals.CGoalDate1;
                this.CGoal2 = goals.CGoal2;
                this.CGoalDate2 = goals.CGoalDate2;
                this.CGoal3 = goals.CGoal3;
                this.CGoalDate3 = goals.CGoalDate3;
                this.CGoal4 = goals.CGoal4;
                this.CGoalDate4 = goals.CGoalDate4;
                this.CGoal5 = goals.CGoal5;
                this.CGoalDate5 = goals.CGoalDate5;
                this.CGoal6 = goals.CGoal6;
                this.CGoalDate6 = goals.CGoalDate6;
                this.CGoal7 = goals.CGoal7;
                this.CGoalDate7 = goals.CGoalDate7;
                this.DGoalName = goals.DGoalName;
                this.DGoalDays = goals.DGoalDays;
                this.DGoalQuestion = goals.DGoalQuestion;
                this.DGoal1 = goals.DGoal1;
                this.DGoalDate1 = goals.DGoalDate1;
                this.DGoal2 = goals.DGoal2;
                this.DGoalDate2 = goals.DGoalDate2;
                this.DGoal3 = goals.DGoal3;
                this.DGoalDate3 = goals.DGoalDate3;
                this.DGoal4 = goals.DGoal4;
                this.DGoalDate4 = goals.DGoalDate4;
                this.DGoal5 = goals.DGoal5;
                this.DGoalDate5 = goals.DGoalDate5;
                this.DGoal6 = goals.DGoal6;
                this.DGoalDate6 = goals.DGoalDate6;
                this.DGoal7 = goals.DGoal7;
                this.DGoalDate7 = goals.DGoalDate7;
                this.EGoalName = goals.EGoalName;
                this.EGoalDays = goals.EGoalDays;
                this.EGoalQuestion = goals.EGoalQuestion;
                this.EGoal1 = goals.EGoal1;
                this.EGoalDate1 = goals.EGoalDate1;
                this.EGoal2 = goals.EGoal2;
                this.EGoalDate2 = goals.EGoalDate2;
                this.EGoal3 = goals.EGoal3;
                this.EGoalDate3 = goals.EGoalDate3;
                this.EGoal4 = goals.EGoal4;
                this.EGoalDate4 = goals.EGoalDate4;
                this.EGoal5 = goals.EGoal5;
                this.EGoalDate5 = goals.EGoalDate5;
                this.EGoal6 = goals.EGoal6;
                this.EGoalDate6 = goals.EGoalDate6;
                this.EGoal7 = goals.EGoal7;
                this.EGoalDate7 = goals.EGoalDate7;
                this.FGoalName = goals.FGoalName;
                this.FGoalDays = goals.FGoalDays;
                this.FGoalQuestion = goals.FGoalQuestion;
                this.FGoal1 = goals.FGoal1;
                this.FGoalDate1 = goals.FGoalDate1;
                this.FGoal2 = goals.FGoal2;
                this.FGoalDate2 = goals.FGoalDate2;
                this.FGoal3 = goals.FGoal3;
                this.FGoalDate3 = goals.FGoalDate3;
                this.FGoal4 = goals.FGoal4;
                this.FGoalDate4 = goals.FGoalDate4;
                this.FGoal5 = goals.FGoal5;
                this.FGoalDate5 = goals.FGoalDate5;
                this.FGoal6 = goals.FGoal6;
                this.FGoalDate6 = goals.FGoalDate6;
                this.FGoal7 = goals.FGoal7;
                this.FGoalDate7 = goals.FGoalDate7;
                this.GGoalName = goals.GGoalName;
                this.GGoalDays = goals.GGoalDays;
                this.GGoalQuestion = goals.GGoalQuestion;
                this.GGoal1 = goals.GGoal1;
                this.GGoalDate1 = goals.GGoalDate1;
                this.GGoal2 = goals.GGoal2;
                this.GGoalDate2 = goals.GGoalDate2;
                this.GGoal3 = goals.GGoal3;
                this.GGoalDate3 = goals.GGoalDate3;
                this.GGoal4 = goals.GGoal4;
                this.GGoalDate4 = goals.GGoalDate4;
                this.GGoal5 = goals.GGoal5;
                this.GGoalDate5 = goals.GGoalDate5;
                this.GGoal6 = goals.GGoal6;
                this.GGoalDate6 = goals.GGoalDate6;
                this.GGoal7 = goals.GGoal7;
                this.GGoalDate7 = goals.GGoalDate7;
                this.HGoalName = goals.HGoalName;
                this.HGoalDays = goals.HGoalDays;
                this.HGoalQuestion = goals.HGoalQuestion;
                this.HGoal1 = goals.HGoal1;
                this.HGoalDate1 = goals.HGoalDate1;
                this.HGoal2 = goals.HGoal2;
                this.HGoalDate2 = goals.HGoalDate2;
                this.HGoal3 = goals.HGoal3;
                this.HGoalDate3 = goals.HGoalDate3;
                this.HGoal4 = goals.HGoal4;
                this.HGoalDate4 = goals.HGoalDate4;
                this.HGoal5 = goals.HGoal5;
                this.HGoalDate5 = goals.HGoalDate5;
                this.HGoal6 = goals.HGoal6;
                this.HGoalDate6 = goals.HGoalDate6;
                this.HGoal7 = goals.HGoal7;
                this.HGoalDate7 = goals.HGoalDate7;
            }
            else { }
        }
    }
}