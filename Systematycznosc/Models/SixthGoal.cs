﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class SixthGoal
    {
        [Key]
        [Column(Order = 1)]
        public int GoalId { get; set; }

        [Key, ForeignKey("UserProfile")]
        [Column(Order = 2)]
        public string UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public string GoalName { get; set; }

        public string GoalQuestion { get; set; }
        public string GoalStatus { get; set; }

        public DateTime? GoalDate { get; set; }
    }
}
