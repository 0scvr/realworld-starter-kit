using System;
using System.ComponentModel.DataAnnotations;

namespace RealWorldMVC.Models
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(90)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }

        public RegisterDto()
        {
        }
    }
}
