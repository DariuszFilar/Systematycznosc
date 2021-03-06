﻿using System.Linq;

namespace Systematycznosc.ViewModels
{
    public class UserProfileViewModelWrapper
    {
        public UserProfileViewModel UserProfileViewModel { get; set; }
        public CredoViewModel CredoViewModel { get; set; }
        public TodoViewModel TodoViewModel { get; set; }
        public BirthdayViewModel BirthdayViewModel { get; set; }
        public RelationshipViewModel RelationshipViewModel { get; set; }
        public GoalsViewModel GoalsViewModel { get; set; }

        public bool IsInitialized => CredoViewModel.Credos != null
            && CredoViewModel.Credos.Any()
            && RelationshipViewModel.Relationships == null
            && TodoViewModel.Todoes != null && TodoViewModel.Todoes.Any() && GoalsViewModel.AGoalName == null
            && GoalsViewModel.BGoalName == null;
    }
}