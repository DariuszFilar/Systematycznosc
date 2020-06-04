using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class FriendsBirthdayViewModel
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
        public UserProfileViewModel UserProfileViewModel { get; set; }

        public FriendsBirthdayViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public FriendsBirthdayViewModel() { }

        public FriendsBirthdayViewModel(FriendsBirthday friendsBirthday)
        {
            if (friendsBirthday != null)
            {
                this.Id = friendsBirthday.Id;
                this.FriendsBirthday1 = friendsBirthday.FriendsBirthday1;
                this.FriendsBirthdayName1 = friendsBirthday.FriendsBirthdayName1;
                this.FriendsBirthday2 = friendsBirthday.FriendsBirthday2;
                this.FriendsBirthdayName2 = friendsBirthday.FriendsBirthdayName2;
                this.FriendsBirthday3 = friendsBirthday.FriendsBirthday3;
                this.FriendsBirthdayName3 = friendsBirthday.FriendsBirthdayName3;
                this.FriendsBirthday4 = friendsBirthday.FriendsBirthday4;
                this.FriendsBirthdayName4 = friendsBirthday.FriendsBirthdayName4;
                this.FriendsBirthday5 = friendsBirthday.FriendsBirthday5;
                this.FriendsBirthdayName5 = friendsBirthday.FriendsBirthdayName5;
                this.FriendsBirthday6 = friendsBirthday.FriendsBirthday6;
                this.FriendsBirthdayName6 = friendsBirthday.FriendsBirthdayName6;
                this.FriendsBirthday7 = friendsBirthday.FriendsBirthday7;
                this.FriendsBirthdayName7 = friendsBirthday.FriendsBirthdayName7;
                this.FriendsBirthday8 = friendsBirthday.FriendsBirthday8;
                this.FriendsBirthdayName8 = friendsBirthday.FriendsBirthdayName8;
                this.FriendsBirthday9 = friendsBirthday.FriendsBirthday9;
                this.FriendsBirthdayName9 = friendsBirthday.FriendsBirthdayName9;
                this.FriendsBirthday10 = friendsBirthday.FriendsBirthday10;
                this.FriendsBirthdayName10 = friendsBirthday.FriendsBirthdayName10;
            }
            else { }
        }
    }
}