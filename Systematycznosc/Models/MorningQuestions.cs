using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class MorningQuestions
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
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
    }
}