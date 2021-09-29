using System;
using System.ComponentModel.DataAnnotations;

namespace RealWorldMVC.Models
{
    public class SignInDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public SignInDto()
        {
        }
    }
}
