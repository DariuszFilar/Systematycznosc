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

        public GoalViewModel(IEnumerable<FirstGoal> firstGoals)
        {
            FirstGoals = firstGoals.ToList();
        }

        public GoalViewModel(IEnumerable<SecondGoal> secondGoals)
        {
            SecondGoals = secondGoals.ToList();
        }

        public GoalViewModel()
        {
        }
    }
}