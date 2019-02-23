using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginRegisterMVC.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}