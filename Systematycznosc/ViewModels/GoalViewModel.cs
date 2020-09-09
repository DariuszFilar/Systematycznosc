using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class GoalViewModel
    {
        public virtual ApplicationUser User { get; set; }

        public List<FirstGoal> FirstGoals { get; set; }
        public List<SecondGoal> SecondGoals { get; set; }
        public List<ThirdGoal> ThirdGoals { get; set; }
        public List<FourthGoal> FourthGoals { get; set; }
        public List<FifthGoal> FifthGoals { get; set; }
        public List<SixthGoal> SixthGoals { get; set; }
        public List<SeventhGoal> SeventhGoals { get; set; }
        public List<EightGoal> EightGoals { get; set; }

        public GoalViewModel(IEnumerable<FirstGoal> firstGoals)
        {
            FirstGoals = firstGoals.ToList();
        }

        public GoalViewModel(IEnumerable<SecondGoal> secondGoals)
        {
            SecondGoals = secondGoals.ToList();
        }

        public GoalViewModel(IEnumerable<ThirdGoal> thirdGoals)
        {
            ThirdGoals = thirdGoals.ToList();
        }
        public GoalViewModel(IEnumerable<FourthGoal> fourthGoals)
        {
            FourthGoals = fourthGoals.ToList();
        }
        public GoalViewModel(IEnumerable<FifthGoal> fifthGoals)
        {
            FifthGoals = fifthGoals.ToList();
        }
        public GoalViewModel(IEnumerable<SixthGoal> sixthGoals)
        {
            SixthGoals = sixthGoals.ToList();
        }
        public GoalViewModel(IEnumerable<SeventhGoal> seventhGoals)
        {
            SeventhGoals = seventhGoals.ToList();
        }
        public GoalViewModel(IEnumerable<EightGoal> eightGoals)
        {
            EightGoals = eightGoals.ToList();
        }

        public GoalViewModel()
        {
        }
    }
}