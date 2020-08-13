using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Systematycznosc.Models
{
    public class ImportantEvent
    {
        [Key]
        [Column(Order = 1)]
        public int ImportantEventId { get; set; }

        [Key, ForeignKey("UserProfile")]
        [Column(Order = 2)]
        public string UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public string ImportantEventName { get; set; }

        public DateTime? ImportantEventDate { get; set; }
    }
}
