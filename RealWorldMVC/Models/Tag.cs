using System;
using System.Collections.Generic;

namespace RealWorldMVC.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string name { get; set; }

        //public virtual ICollection<Article> Articles { get; set; }
        // Limit up to 5 tags per article to avoid overflow
        public Tag()
        {
        }
    }
}
