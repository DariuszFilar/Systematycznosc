using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systematycznosc.ViewModels
{
    public class UserProfileViewModelWrapper
    {
        public UserProfileViewModel UserProfileViewModel { get; set; }
        public CredoViewModel CredoViewModel { get; set; }
        public UserProfileViewModelWrapper() { }
        public MorningQuestionsViewModel MorningQuestionsViewModel { get; set; }
        public EveningQuestionsViewModel EveningQuestionsViewModel { get; set; }
        public TodoViewModel TodoViewModel { get; set; }
        public FamilyBirthdayViewModel FamilyBirthdayViewModel { get; set; }
        public FriendsBirthdayViewModel FriendsBirthdayViewModel { get; set; }
        public OthersBirthdayViewModel OthersBirthdayViewModel { get; set; }
        public RelationshipViewModel RelationshipViewModel { get; set; }
        public GoalsViewModel GoalsViewModel { get; set; }
        public UserProfileViewModelWrapper(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
            this.CredoViewModel = new CredoViewModel();

        }

    }
}