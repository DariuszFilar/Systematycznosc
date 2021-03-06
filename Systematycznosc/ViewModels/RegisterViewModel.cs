﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Systematycznosc.ViewModels
{
    public class RegisterViewModel
    {
        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Wymagany jest adres Email.")]
        [EmailAddress(ErrorMessage = "Niepoprawny format Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wpisać hasło <br/>")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć minimum {2} znaków.<br/> ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Hasła nie są identyczne.<br/>")]
        public string ConfirmPassword { get; set; }


    }
}