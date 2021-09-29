using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealWorldMVC.Models
{
    public class Tag
    {
        public Guid Id { get; set; }

        [Required]
        public string name { get; set; }
        public ICollection<Article> Articles { get; set; }

        public Tag()
        {
        }
    }
}
