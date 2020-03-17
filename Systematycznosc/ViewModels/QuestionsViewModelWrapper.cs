using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Systematycznosc.ViewModels
{
    public class QuestionsViewModelWrapper
    {
        public QuestionsViewModelWrapper QuestionsViewModel { get; set; }
        public UserProfileViewModel UserProfileViewModel { get; set; }
        public MorningQuestionsViewModel MorningQuestionsViewModel { get; set; }
        public EveningQuestionsViewModel EveningQuestionsViewModel { get; set; }

        public QuestionsViewModelWrapper() { }

        public QuestionsViewModelWrapper(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
            this.MorningQuestionsViewModel = new MorningQuestionsViewModel();
            this.EveningQuestionsViewModel = new EveningQuestionsViewModel();
        }
    }
}