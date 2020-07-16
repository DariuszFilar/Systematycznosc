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
        public virtual ApplicationUser User { get; set; }

        public List<Credo> Credos { get; set; }

        public CredoViewModel(IEnumerable<Credo> credos)
        {
            Credos = credos.ToList();
        }

        public CredoViewModel()
        {
        }
    }
}