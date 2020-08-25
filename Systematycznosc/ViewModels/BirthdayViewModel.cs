using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;


namespace Systematycznosc.ViewModels
{
    public class BirthdayViewModel
    {
        public virtual ApplicationUser User { get; set; }

        public List<FamilyBirthday> FamilyBirthdays { get; set; }
        public List<FriendBirthday> FriendsBirthdays { get; set; }
        public List<OtherBirthday> OthersBirthdays { get; set; }

        public BirthdayViewModel(IEnumerable<FamilyBirthday> familyBirthdays)
        {
            FamilyBirthdays = familyBirthdays.ToList();
        }

        public BirthdayViewModel(IEnumerable<FriendBirthday> friendsBirthdays)
        {
            FriendsBirthdays = friendsBirthdays.ToList();
        }
        public BirthdayViewModel(IEnumerable<OtherBirthday> othersBirthdays)
        {
            OthersBirthdays = othersBirthdays.ToList();
        }

        public BirthdayViewModel()
        {
        }
    }
}