using System;
using System.ComponentModel.DataAnnotations;

namespace RealWorldMVC.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid ArticleId { get; set; }

        public AppUser Author { get; set; }
        public Article Article { get; set; }

        public Comment()
        {
        }
    }
}
