using System;
using System.Collections.Generic;

namespace RealWorld.Models;
public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Article> Articles { get; set; }


    public User()
    {
    }
}
