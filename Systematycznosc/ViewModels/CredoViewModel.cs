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

        public List<string> Credos { get; set; }
        
        public CredoViewModel(Credo credo)
        {
            if (credo != null)
            {
                Credos = new List<string>()
                {
                    credo.Credo1,
                    credo.Credo2,
                    credo.Credo3,
                    credo.Credo4,
                    credo.Credo5,
                    credo.Credo6,
                    credo.Credo7,
                    credo.Credo8,
                    credo.Credo9,
                    credo.Credo10
                };
            }
        }
    }
}