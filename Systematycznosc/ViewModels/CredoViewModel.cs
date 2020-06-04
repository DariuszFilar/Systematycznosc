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

        public UserProfileViewModel UserProfileViewModel { get; set; }

        //public CredoViewModel(UserProfile userProfile)
        //{
        //    this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        //}
        //public CredoViewModel() { }

        public CredoViewModel(UserProfile userProfile = null)
        {
            if(userProfile != null)
                this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }

        public CredoViewModel()
        {

        }

        public CredoViewModel(Credo credo)
        {
            if (credo != null)
            {
                this.Id = credo.Id;
                this.Credo1 = credo.Credo1;
                this.Credo2 = credo.Credo2;
                this.Credo3 = credo.Credo3;
                this.Credo4 = credo.Credo4;
                this.Credo5 = credo.Credo5;
                this.Credo6 = credo.Credo6;
                this.Credo7 = credo.Credo7;
                this.Credo8 = credo.Credo8;
                this.Credo9 = credo.Credo9;
                this.Credo10 = credo.Credo10;
            }
            else { };
        }
    }
}