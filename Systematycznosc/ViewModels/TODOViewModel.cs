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
        public DateTime? TodoDate1 { get; set; }
        public string TodoDateName1 { get; set; }
        public DateTime? TodoDate2 { get; set; }
        public string TodoDateName2 { get; set; }
        public DateTime? TodoDate3 { get; set; }
        public string TodoDateName3 { get; set; }
        public DateTime? TodoDate4 { get; set; }
        public string TodoDateName4 { get; set; }
        public DateTime? TodoDate5 { get; set; }
        public string TodoDateName5 { get; set; }
        public DateTime? TodoDate6 { get; set; }
        public string TodoDateName6 { get; set; }
        public DateTime? TodoDate7 { get; set; }
        public string TodoDateName7 { get; set; }
        public DateTime? TodoDate8 { get; set; }
        public string TodoDateName8 { get; set; }
        public DateTime? TodoDate9 { get; set; }
        public string TodoDateName9 { get; set; }
        public DateTime? TodoDate10 { get; set; }
        public string TodoDateName10 { get; set; }
        public DateTime? TodoDate11 { get; set; }
        public string TodoDateName11 { get; set; }

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
            this.TodoDateName1 = todo.TodoDateName1;
            this.TodoDateName2 = todo.TodoDateName2;
            this.TodoDateName3 = todo.TodoDateName3;
            this.TodoDateName4 = todo.TodoDateName4;
            this.TodoDateName5 = todo.TodoDateName5;
            this.TodoDateName6 = todo.TodoDateName6;
            this.TodoDateName7 = todo.TodoDateName7;
            this.TodoDateName8 = todo.TodoDateName8;
            this.TodoDateName9 = todo.TodoDateName9;
            this.TodoDateName10 = todo.TodoDateName10;
            this.TodoDateName11 = todo.TodoDateName11;
            this.TodoDate1 = todo.TodoDate1;
            this.TodoDate2 = todo.TodoDate2;
            this.TodoDate3 = todo.TodoDate3;
            this.TodoDate4 = todo.TodoDate4;
            this.TodoDate5 = todo.TodoDate5;
            this.TodoDate6 = todo.TodoDate6;
            this.TodoDate7 = todo.TodoDate7;
            this.TodoDate8 = todo.TodoDate8;
            this.TodoDate9 = todo.TodoDate9;
            this.TodoDate10 = todo.TodoDate10;
            this.TodoDate11 = todo.TodoDate11;
        }
    }
}