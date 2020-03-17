using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class EveningQuestionsViewModel
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string EveningQuestion1 { get; set; }
        public string EveningQuestion2 { get; set; }
        public string EveningQuestion3 { get; set; }
        public string EveningQuestion4 { get; set; }
        public string EveningQuestion5 { get; set; }
        public string EveningQuestion6 { get; set; }
        public string EveningQuestion7 { get; set; }
        public string EveningQuestion8 { get; set; }
        public string EveningQuestion9 { get; set; }
        public string EveningQuestion10 { get; set; }
        public string EveningQuestion11 { get; set; }

        public UserProfileViewModel UserProfileViewModel { get; set; }

        public EveningQuestionsViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public EveningQuestionsViewModel() { }

        public EveningQuestionsViewModel(EveningQuestions eveningQuestions)
        {
            this.Id = eveningQuestions.Id;
            this.EveningQuestion1 = eveningQuestions.EveningQuestions1;
            this.EveningQuestion2 = eveningQuestions.EveningQuestions2;
            this.EveningQuestion3 = eveningQuestions.EveningQuestions3;
            this.EveningQuestion4 = eveningQuestions.EveningQuestions4;
            this.EveningQuestion5 = eveningQuestions.EveningQuestions5;
            this.EveningQuestion6 = eveningQuestions.EveningQuestions6;
            this.EveningQuestion7 = eveningQuestions.EveningQuestions7;
            this.EveningQuestion8 = eveningQuestions.EveningQuestions8;
            this.EveningQuestion9 = eveningQuestions.EveningQuestions9;
            this.EveningQuestion10 = eveningQuestions.EveningQuestions10;
        }
    }
}