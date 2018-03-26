

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VendingWeb.Models
{
    public class UserModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The passwords much match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}