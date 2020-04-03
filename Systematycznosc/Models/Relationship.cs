using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class Relationship
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Relationship1 { get; set; }
        public string Relationship2 { get; set; }
        public string Relationship3 { get; set; }
        public string Relationship4 { get; set; }
        public string Relationship5 { get; set; }
        public string Relationship6 { get; set; }
        public string Relationship7 { get; set; }
        public string Relationship8 { get; set; }
        public string Relationship9 { get; set; }
        public string Relationship10 { get; set; }
        public string Relationship11 { get; set; }
    }
}