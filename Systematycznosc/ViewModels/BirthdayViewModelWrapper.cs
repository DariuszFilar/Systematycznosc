using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systematycznosc.ViewModels
{
    public class BirthdayViewModelWrapper
    {
        public BirthdayViewModelWrapper BirthdayViewModel { get; set; }
        public FamilyBirthdayViewModel FamilyBirthdayViewModel { get; set; }
        public FriendsBirthdayViewModel FriendsBirthdayViewModel { get; set; }
        public OthersBirthdayViewModel OthersBirthdayViewModel { get; set; }
        public UserProfileViewModel UserProfileViewModel { get; set; }
        

        public BirthdayViewModelWrapper() { }

        public BirthdayViewModelWrapper(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
            this.FamilyBirthdayViewModel = new FamilyBirthdayViewModel();
            this.FriendsBirthdayViewModel = new FriendsBirthdayViewModel();
            this.OthersBirthdayViewModel = new OthersBirthdayViewModel();
        }
    }
}