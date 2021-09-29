using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealWorldMVC.Models
{
    public class Article
    {
        public Guid Id { get; set; }
        //[Index(IsUnique = true)]
        [Required]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public AppUser Author { get; set; }

        public Article()
        {
        }
    }
}
