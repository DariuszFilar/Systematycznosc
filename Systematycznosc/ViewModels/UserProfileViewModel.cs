using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Systematycznosc.ViewModels
{
    public class UserProfileViewModel
    {
        public string Name { get; set; }

        public string Nickname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Id { get; set; }

        public string Gender { get; set; }

        public int Age => GetAge(BirthDate);

        private static int GetAge(DateTime asd)
        {
            var timespan = DateTime.Now - asd;
            var age = timespan.Days / 365;

            return age;
        }
    }
}