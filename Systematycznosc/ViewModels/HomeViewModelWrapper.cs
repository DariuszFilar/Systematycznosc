using Microsoft.Ajax.Utilities;
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

         CredoViewModel.Credos.Any(x => x.CredoValue != null) |
         RelationshipViewModel.Relationships.Any(x => x.RelationshipValue != null) |
         TodoViewModel.Todoes.Any(x => x.TodoValue != null) |
         TodoViewModel.ImportantEvents.Any(x => x.ImportantEventName != null) |
         BirthdayViewModel.FamilyBirthdays.Any(x => x.FamilyBirthdayName != null) |
         BirthdayViewModel.FriendsBirthdays.Any(x => x.FriendBirthdayName != null) |
         BirthdayViewModel.OthersBirthdays.Any(x => x.OtherBirthdayName != null) |
         RelationshipViewModel.Relationships.Any(x => x.RelationshipValue != null) |
         GoalViewModel.FirstGoals.Any(x => x.GoalName != null) |
         GoalViewModel.SecondGoals.Any(x => x.GoalName != null) |
         GoalViewModel.ThirdGoals.Any(x => x.GoalName != null) |
         GoalViewModel.FourthGoals.Any(x => x.GoalName != null) |
         GoalViewModel.FifthGoals.Any(x => x.GoalName != null) |
         GoalViewModel.SixthGoals.Any(x => x.GoalName != null) |
         GoalViewModel.SeventhGoals.Any(x => x.GoalName != null) |
         GoalViewModel.EightGoals.Any(x => x.GoalName != null);
    }
}