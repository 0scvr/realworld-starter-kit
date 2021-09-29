using System;
using System.ComponentModel.DataAnnotations;

namespace RealWorldMVC.Models
{
    public class NewOrEditArticleDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Body of article is required")]
        public string Body { get; set; }
        //public string[] Tags { get; set; }

        public Guid AuthorId { get; set; }

        public NewOrEditArticleDto()
        {
        }
    }
}
