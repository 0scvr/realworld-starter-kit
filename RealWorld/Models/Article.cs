using System;
using System.Collections.Generic;

namespace RealWorld.Models;
public class Article
{
    public Guid Id { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid AuthorId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
    //public virtual ICollection<Tag> Tags { get; set; }
    public virtual User Author { get; set; }

    public Article()
    {
    }
}
