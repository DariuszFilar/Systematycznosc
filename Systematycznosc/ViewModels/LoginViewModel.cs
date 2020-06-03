using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Systematycznosc.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Wymagany jest adres Email.")]
        [EmailAddress(ErrorMessage = "Niepoprawny format Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wpisać hasło")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie?")]
        public bool RememberMe { get; set; }
    }
}