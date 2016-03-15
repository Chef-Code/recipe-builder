﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    //IdentityUser<TKey, TLogin, TRole, TClaim>
    public class Member : IdentityUser
    {
        //Member has access to all IdentityUser Properties
        public int MemberID { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}