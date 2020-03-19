using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Systematycznosc.Models;

namespace Systematycznosc.ViewModels
{
    public class TodoViewModel
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Todo1 { get; set; }
        public string Todo2 { get; set; }
        public string Todo3 { get; set; }
        public string Todo4 { get; set; }
        public string Todo5 { get; set; }
        public string Todo6 { get; set; }
        public string Todo7 { get; set; }
        public string Todo8 { get; set; }
        public string Todo9 { get; set; }
        public string Todo10 { get; set; }
        public string Todo111 { get; set; }

        public UserProfileViewModel UserProfileViewModel { get; set; }
        public TodoViewModel(UserProfile userProfile)
        {
            this.UserProfileViewModel = new UserProfileViewModel(userProfile);
        }
        public TodoViewModel() { }

        public TodoViewModel(Todo todo)
        {
            this.Id = todo.Id;
            this.Todo1 = todo.Todo1;
            this.Todo2 = todo.Todo2;
            this.Todo3 = todo.Todo3;
            this.Todo4 = todo.Todo4;
            this.Todo5 = todo.Todo5;
            this.Todo6 = todo.Todo6;
            this.Todo7 = todo.Todo7;
            this.Todo8 = todo.Todo8;
            this.Todo9 = todo.Todo9;
            this.Todo10 = todo.Todo10;
        }
    }
}