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

        public EveningQuestionsViewModel(EveningQuestions eveningQuestions)
        {
            if (eveningQuestions != null)
            {
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

        public EveningQuestionsViewModel()
        {
        }
    }
}