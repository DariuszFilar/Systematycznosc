using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class FriendsBirthday
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime? FriendsBirthday1 { get; set; }
        public string FriendsBirthdayName1 { get; set; }
        public DateTime? FriendsBirthday2 { get; set; }
        public string FriendsBirthdayName2 { get; set; }
        public DateTime? FriendsBirthday3 { get; set; }
        public string FriendsBirthdayName3 { get; set; }
        public DateTime? FriendsBirthday4 { get; set; }
        public string FriendsBirthdayName4 { get; set; }
        public DateTime? FriendsBirthday5 { get; set; }
        public string FriendsBirthdayName5 { get; set; }
        public DateTime? FriendsBirthday6 { get; set; }
        public string FriendsBirthdayName6 { get; set; }
        public DateTime? FriendsBirthday7 { get; set; }
        public string FriendsBirthdayName7 { get; set; }
        public DateTime? FriendsBirthday8 { get; set; }
        public string FriendsBirthdayName8 { get; set; }
        public DateTime? FriendsBirthday9 { get; set; }
        public string FriendsBirthdayName9 { get; set; }
        public DateTime? FriendsBirthday10 { get; set; }
        public string FriendsBirthdayName10 { get; set; }
        public DateTime? FriendsBirthday11 { get; set; }
        public string FriendsBirthdayName11 { get; set; }
    }
}