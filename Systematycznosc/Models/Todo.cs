using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class Todo
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Todo1 { get; set; }
        public string Todo2 { get; set; }
        public string Todo3 { get; set; }
        public string Todo4 { get; set; }
        public string Todo5 { get; set; }
        public string Todo6 { get; set; }
        public string Todo7 { get; set; }
        public string Todo8 { get; set; }
        public string Todo9 { get; set; }
        public string Todo10 { get; set; }
        public string Todo11 { get; set; }
        public DateTime? TodoDate1 { get; set; }
        public string TodoDateName1 { get; set; }
        public DateTime? TodoDate2 { get; set; }
        public string TodoDateName2 { get; set; }
        public DateTime? TodoDate3 { get; set; }
        public string TodoDateName3 { get; set; }
        public DateTime? TodoDate4 { get; set; }
        public string TodoDateName4 { get; set; }
        public DateTime? TodoDate5 { get; set; }
        public string TodoDateName5 { get; set; }
        public DateTime? TodoDate6 { get; set; }
        public string TodoDateName6 { get; set; }
        public DateTime? TodoDate7 { get; set; }
        public string TodoDateName7 { get; set; }
        public DateTime? TodoDate8 { get; set; }
        public string TodoDateName8 { get; set; }
        public DateTime? TodoDate9 { get; set; }
        public string TodoDateName9 { get; set; }
        public DateTime? TodoDate10 { get; set; }
        public string TodoDateName10 { get; set; }
        public DateTime? TodoDate11 { get; set; }
        public string TodoDateName11 { get; set; }
    }
}