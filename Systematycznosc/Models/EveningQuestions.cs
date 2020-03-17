using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class EveningQuestions
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string EveningQuestions1 { get; set; }
        public string EveningQuestions2 { get; set; }
        public string EveningQuestions3 { get; set; }
        public string EveningQuestions4 { get; set; }
        public string EveningQuestions5 { get; set; }
        public string EveningQuestions6 { get; set; }
        public string EveningQuestions7 { get; set; }
        public string EveningQuestions8 { get; set; }
        public string EveningQuestions9 { get; set; }
        public string EveningQuestions10 { get; set; }
        public string EveningQuestions11 { get; set; }
    }
}