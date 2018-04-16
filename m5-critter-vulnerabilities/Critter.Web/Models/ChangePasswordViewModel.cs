using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Critter.Web.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "New Password:")]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or more")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()]))(?=.*[\da-zA-Z!@#$%^&*()]).{8,128}$", ErrorMessage = "Password must meet the requirements")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Compare("NewPassword", ErrorMessage ="Passwords do not match")]
        [Display(Name = "Confirm Password:")]
        public string ConfirmPassword { get; set; }
    }
}