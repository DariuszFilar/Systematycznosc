using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class QuestionViewModel
    {
        public virtual ApplicationUser User { get; set; }

        public List<MorningQuestion> MorningQuestions { get; set; }
        public List<EveningQuestion> EveningQuestions { get; set; }

        public QuestionViewModel(IEnumerable<MorningQuestion> morningQuestions)
        {
            MorningQuestions = morningQuestions.ToList();
        }

        public QuestionViewModel(IEnumerable<EveningQuestion> eveningQuestions)
        {
            EveningQuestions = eveningQuestions.ToList();
        }

        public QuestionViewModel()
        {
        }
    }
}