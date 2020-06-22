using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class FamilyBirthdayViewModel
    {
        public virtual ApplicationUser User { get; set; }
        public DateTime? FamilyBirthday1 { get; set; }
        public string FamilyBirthdayName1 { get; set; }
        public DateTime? FamilyBirthday2 { get; set; }
        public string FamilyBirthdayName2 { get; set; }
        public DateTime? FamilyBirthday3 { get; set; }
        public string FamilyBirthdayName3 { get; set; }
        public DateTime? FamilyBirthday4 { get; set; }
        public string FamilyBirthdayName4 { get; set; }
        public DateTime? FamilyBirthday5 { get; set; }
        public string FamilyBirthdayName5 { get; set; }
        public DateTime? FamilyBirthday6 { get; set; }
        public string FamilyBirthdayName6 { get; set; }
        public DateTime? FamilyBirthday7 { get; set; }
        public string FamilyBirthdayName7 { get; set; }
        public DateTime? FamilyBirthday8 { get; set; }
        public string FamilyBirthdayName8 { get; set; }
        public DateTime? FamilyBirthday9 { get; set; }
        public string FamilyBirthdayName9 { get; set; }
        public DateTime? FamilyBirthday10 { get; set; }
        public string FamilyBirthdayName10 { get; set; }
        public DateTime? FamilyBirthday11 { get; set; }
        public string FamilyBirthdayName11 { get; set; }
        public FamilyBirthdayViewModel() { }

        public FamilyBirthdayViewModel(FamilyBirthday familyBirthday)
        {
            if (familyBirthday != null)
            {
                this.FamilyBirthday1 = familyBirthday.FamilyBirthday1;
                this.FamilyBirthdayName1 = familyBirthday.FamilyBirthdayName1;
                this.FamilyBirthday2 = familyBirthday.FamilyBirthday2;
                this.FamilyBirthdayName2 = familyBirthday.FamilyBirthdayName2;
                this.FamilyBirthday3 = familyBirthday.FamilyBirthday3;
                this.FamilyBirthdayName3 = familyBirthday.FamilyBirthdayName3;
                this.FamilyBirthday4 = familyBirthday.FamilyBirthday4;
                this.FamilyBirthdayName4 = familyBirthday.FamilyBirthdayName4;
                this.FamilyBirthday5 = familyBirthday.FamilyBirthday5;
                this.FamilyBirthdayName5 = familyBirthday.FamilyBirthdayName5;
                this.FamilyBirthday6 = familyBirthday.FamilyBirthday6;
                this.FamilyBirthdayName6 = familyBirthday.FamilyBirthdayName6;
                this.FamilyBirthday7 = familyBirthday.FamilyBirthday7;
                this.FamilyBirthdayName7 = familyBirthday.FamilyBirthdayName7;
                this.FamilyBirthday8 = familyBirthday.FamilyBirthday8;
                this.FamilyBirthdayName8 = familyBirthday.FamilyBirthdayName8;
                this.FamilyBirthday9 = familyBirthday.FamilyBirthday9;
                this.FamilyBirthdayName9 = familyBirthday.FamilyBirthdayName9;
                this.FamilyBirthday10 = familyBirthday.FamilyBirthday10;
                this.FamilyBirthdayName10 = familyBirthday.FamilyBirthdayName10;
            }
        }
    }
}