using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class OthersBirthday
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime? OthersBirthday1 { get; set; }
        public string OthersBirthdayName1 { get; set; }
        public DateTime? OthersBirthday2 { get; set; }
        public string OthersBirthdayName2 { get; set; }
        public DateTime? OthersBirthday3 { get; set; }
        public string OthersBirthdayName3 { get; set; }
        public DateTime? OthersBirthday4 { get; set; }
        public string OthersBirthdayName4 { get; set; }
        public DateTime? OthersBirthday5 { get; set; }
        public string OthersBirthdayName5 { get; set; }
        public DateTime? OthersBirthday6 { get; set; }
        public string OthersBirthdayName6 { get; set; }
        public DateTime? OthersBirthday7 { get; set; }
        public string OthersBirthdayName7 { get; set; }
        public DateTime? OthersBirthday8 { get; set; }
        public string OthersBirthdayName8 { get; set; }
        public DateTime? OthersBirthday9 { get; set; }
        public string OthersBirthdayName9 { get; set; }
        public DateTime? OthersBirthday10 { get; set; }
        public string OthersBirthdayName10 { get; set; }
        public DateTime? OthersBirthday11 { get; set; }
        public string OthersBirthdayName11 { get; set; }
    }
}