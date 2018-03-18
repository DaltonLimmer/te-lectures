using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forms.Web.Models
{
    /* 1. Add a model for our input page */
    public class UserRegistrationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}