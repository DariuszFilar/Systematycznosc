using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systematycznosc.ViewModels
{
    public class HomeViewModelWrapper
    {
        public UserProfileViewModel UserProfileViewModel { get; set; }
        public CredoViewModel CredoViewModel { get; set; }
        public TodoViewModel TodoViewModel { get; set; }
        public BirthdayViewModel BirthdayViewModel { get; set; }
        public RelationshipViewModel RelationshipViewModel { get; set; }
        public GoalViewModel GoalViewModel { get; set; }
        public QuestionViewModel QuestionViewModel { get; set; }

        public bool IsInitialized =>
            CredoViewModel.Credos.Any()
                        && RelationshipViewModel.Relationships.Any() &&
                        TodoViewModel.Todoes.Any() && TodoViewModel.ImportantEvents.Any() &&
              BirthdayViewModel.FriendsBirthdays != null &&
            BirthdayViewModel.FamilyBirthdays.Any() && BirthdayViewModel.FamilyBirthdays.Any() && BirthdayViewModel.OthersBirthdays.Any() &&
            RelationshipViewModel.Relationships.Any() &&
            GoalViewModel.FirstGoals.Any() && GoalViewModel.SecondGoals.Any() && GoalViewModel.ThirdGoals.Any() && GoalViewModel.FourthGoals.Any() &&
            GoalViewModel.FifthGoals.Any() && GoalViewModel.SixthGoals.Any() && GoalViewModel.SeventhGoals.Any() && GoalViewModel.EightGoals.Any();
    }
}