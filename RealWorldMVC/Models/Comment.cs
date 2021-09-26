using System;
using System.Collections.Generic;

namespace RealWorldMVC.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ArticleId { get; set; }

        public virtual User Author { get; set; }
        public virtual Article Article { get; set; }

        public Comment()
        {
        }
    }
}
