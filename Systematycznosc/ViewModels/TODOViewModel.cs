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
        public virtual ApplicationUser User { get; set; }

        public List<Todo> Todoes { get; set; }
        public List<ImportantEvent> ImportantEvents { get; set; }

        public TodoViewModel(IEnumerable<Todo> todoes)
        {
            Todoes = todoes.ToList();
        }

        public TodoViewModel(IEnumerable<ImportantEvent> importantEvents)
        {
            ImportantEvents = importantEvents.ToList();
        }

        public TodoViewModel()
        {
        }
    }
}