using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class CredoViewModel
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Credo1 { get; set; }
        public string Credo2 { get; set; }
        public string Credo3 { get; set; }
        public string Credo4 { get; set; }
        public string Credo5 { get; set; }
        public string Credo6 { get; set; }
        public string Credo7 { get; set; }
        public string Credo8 { get; set; }
        public string Credo9 { get; set; }
        public string Credo10 { get; set; }
        public string Credo11 { get; set; }
    }
}