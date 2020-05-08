﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Systematycznosc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
        public Credo Credo { get; set; }
        public MorningQuestions MorningQuestions { get; set; }
        public EveningQuestions EveningQuestions { get; set; }
        public FamilyBirthday FamilyBirthday { get; set; }
        public FriendsBirthday FriendsBirthday { get; set; }
        public OthersBirthday OthersBirthday { get; set; }
        public Todo Todo { get; set; }
        public Relationship Relationship { get; set; }
        public Goals Goals { get; set; }
       
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}