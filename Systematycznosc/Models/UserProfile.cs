﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class UserProfile
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }
        
    }
}