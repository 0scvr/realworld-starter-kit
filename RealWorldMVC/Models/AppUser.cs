using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RealWorldMVC.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Bio { get; set; }
        public string Image { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Article> Articles { get; set; }


        public AppUser()
        {
        }
    }
}
