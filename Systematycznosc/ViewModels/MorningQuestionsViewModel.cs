using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class MorningQuestionsViewModel
    {
        public virtual ApplicationUser User { get; set; }
        public string MorningQuestions1 { get; set; }
        public string MorningQuestions2 { get; set; }
        public string MorningQuestions3 { get; set; }
        public string MorningQuestions4 { get; set; }
        public string MorningQuestions5 { get; set; }
        public string MorningQuestions6 { get; set; }
        public string MorningQuestions7 { get; set; }
        public string MorningQuestions8 { get; set; }
        public string MorningQuestions9 { get; set; }
        public string MorningQuestions10 { get; set; }
        public string MorningQuestions11 { get; set; }

        public MorningQuestionsViewModel() { }
        public MorningQuestionsViewModel(MorningQuestions morningQuestions)
        {
            if (morningQuestions != null)
            {
                this.MorningQuestions1 = morningQuestions.MorningQuestions1;
                this.MorningQuestions2 = morningQuestions.MorningQuestions2;
                this.MorningQuestions3 = morningQuestions.MorningQuestions3;
                this.MorningQuestions4 = morningQuestions.MorningQuestions4;
                this.MorningQuestions5 = morningQuestions.MorningQuestions5;
                this.MorningQuestions6 = morningQuestions.MorningQuestions6;
                this.MorningQuestions7 = morningQuestions.MorningQuestions7;
                this.MorningQuestions8 = morningQuestions.MorningQuestions8;
                this.MorningQuestions9 = morningQuestions.MorningQuestions9;
                this.MorningQuestions10 = morningQuestions.MorningQuestions10;
            }
        }
    }
}