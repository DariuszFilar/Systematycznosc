using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class FamilyBirthday
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime FamilyBirthday1 { get; set; }
        public string FamilyBirthdayName1 { get; set; }
        public DateTime FamilyBirthday2 { get; set; }
        public string FamilyBirthdayName2 { get; set; }
        public DateTime FamilyBirthday3 { get; set; }
        public string FamilyBirthdayName3 { get; set; }
        public DateTime FamilyBirthday4 { get; set; }
        public string FamilyBirthdayName4 { get; set; }
        public DateTime FamilyBirthday5 { get; set; }
        public string FamilyBirthdayName5 { get; set; }
        public DateTime FamilyBirthday6 { get; set; }
        public string FamilyBirthdayName6 { get; set; }
        public DateTime FamilyBirthday7 { get; set; }
        public string FamilyBirthdayName7 { get; set; }
        public DateTime FamilyBirthday8 { get; set; }
        public string FamilyBirthdayName8 { get; set; }
        public DateTime FamilyBirthday9 { get; set; }
        public string FamilyBirthdayName9 { get; set; }
        public DateTime FamilyBirthday10 { get; set; }
        public string FamilyBirthdayName10 { get; set; }
        public DateTime FamilyBirthday11 { get; set; }
        public string FamilyBirthdayName11 { get; set; }
    }
}