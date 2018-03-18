using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forms.Web.Models
{
    /* 6. Create a Form Model that has fields we want to display on a form. */
    public class FormModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Subscribe { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string FavoriteColor { get; set; }
    }
}