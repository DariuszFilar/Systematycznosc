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
    }
}