using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systematycznosc.ViewModels
{
    public class GoalsViewModelWrapper
    {
        public Goals1ViewModel Goals1ViewModel { get; set; }
        public UserProfileViewModel UserProfileViewModel { get; set; }

        public GoalsViewModelWrapper() { }

        public GoalsViewModelWrapper(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
            this.Goals1ViewModel = new Goals1ViewModel();
        }
    }
}