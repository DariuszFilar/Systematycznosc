using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class OthersBirthdayViewModel
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime OthersBirthday1 { get; set; }
        public string OthersBirthdayName1 { get; set; }
        public DateTime OthersBirthday2 { get; set; }
        public string OthersBirthdayName2 { get; set; }
        public DateTime OthersBirthday3 { get; set; }
        public string OthersBirthdayName3 { get; set; }
        public DateTime OthersBirthday4 { get; set; }
        public string OthersBirthdayName4 { get; set; }
        public DateTime OthersBirthday5 { get; set; }
        public string OthersBirthdayName5 { get; set; }
        public DateTime OthersBirthday6 { get; set; }
        public string OthersBirthdayName6 { get; set; }
        public DateTime OthersBirthday7 { get; set; }
        public string OthersBirthdayName7 { get; set; }
        public DateTime OthersBirthday8 { get; set; }
        public string OthersBirthdayName8 { get; set; }
        public DateTime OthersBirthday9 { get; set; }
        public string OthersBirthdayName9 { get; set; }
        public DateTime OthersBirthday10 { get; set; }
        public string OthersBirthdayName10 { get; set; }
        public DateTime OthersBirthday11 { get; set; }
        public string OthersBirthdayName11 { get; set; }
        public UserProfileViewModel UserProfileViewModel { get; set; }

        public OthersBirthdayViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public OthersBirthdayViewModel() { }

        public OthersBirthdayViewModel(OthersBirthday othersBirthday)
        {
            this.Id = othersBirthday.Id;
            this.OthersBirthday1 = othersBirthday.OthersBirthday1;
            this.OthersBirthdayName1 = othersBirthday.OthersBirthdayName1;
            this.OthersBirthday2 = othersBirthday.OthersBirthday2;
            this.OthersBirthdayName2 = othersBirthday.OthersBirthdayName2;
            this.OthersBirthday3 = othersBirthday.OthersBirthday3;
            this.OthersBirthdayName3 = othersBirthday.OthersBirthdayName3;
            this.OthersBirthday4 = othersBirthday.OthersBirthday4;
            this.OthersBirthdayName4 = othersBirthday.OthersBirthdayName4;
            this.OthersBirthday5 = othersBirthday.OthersBirthday5;
            this.OthersBirthdayName5 = othersBirthday.OthersBirthdayName5;
            this.OthersBirthday6 = othersBirthday.OthersBirthday6;
            this.OthersBirthdayName6 = othersBirthday.OthersBirthdayName6;
            this.OthersBirthday7 = othersBirthday.OthersBirthday7;
            this.OthersBirthdayName7 = othersBirthday.OthersBirthdayName7;
            this.OthersBirthday8 = othersBirthday.OthersBirthday8;
            this.OthersBirthdayName8 = othersBirthday.OthersBirthdayName8;
            this.OthersBirthday9 = othersBirthday.OthersBirthday9;
            this.OthersBirthdayName9 = othersBirthday.OthersBirthdayName9;
            this.OthersBirthday10 = othersBirthday.OthersBirthday10;
            this.OthersBirthdayName10 = othersBirthday.OthersBirthdayName10;
        }
    }
}