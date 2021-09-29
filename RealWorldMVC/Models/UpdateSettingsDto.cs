using System;
using System.ComponentModel.DataAnnotations;

namespace RealWorldMVC.Models
{
    public class UpdateSettingsDto
    {
        [Url(ErrorMessage ="Invalid image URL")]
        public string ImageUrl { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

        public UpdateSettingsDto()
        {
        }
    }
}
