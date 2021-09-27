using System;
using System.ComponentModel.DataAnnotations;

namespace RealWorldMVC.Models
{
    public class UserRegistrationDto
    {
        public UserRegistrationDto()
        {
        }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(150)]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
