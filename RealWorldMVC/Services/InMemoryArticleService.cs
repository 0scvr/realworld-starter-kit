using System;
using System.Threading.Tasks;
using RealWorldMVC.Models;

namespace RealWorldMVC.Services
{
    public class InMemoryArticleService : IArticleService
    {
        public InMemoryArticleService()
        {
        }

        public Task<Article[]> GetArticlesAsync()
        {
            var art1 = new Article
            {
                Id = Guid.Empty,
                Slug = "article-one",
                Title = "My first article",
                Description = "lalalalalalal",
                Body = "hjdjdhdjsdjjsdjhds dsjdsjkdsjksd",
                TagList = new[] { "hello", "world" },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AuthorId = Guid.Empty
            };
            var art2 = new Article
            {
                Id = Guid.Empty,
                Slug = "article-two",
                Title = "My second article",
                Description = "lalalalalalal",
                Body = "hjdjdhdjsdjjsdjhds dsjdsjkdsjksd",
                TagList = new[] { "hello" },
                CreatedAt = DateTime.Now.AddHours(-1),
                UpdatedAt = DateTime.Now.AddHours(-1),
                AuthorId = Guid.Empty
            };

            return Task.FromResult(new[] { art1, art2 });
        }

        public Task<Article> GetArticleBySlugAsync(string slug)
        {
            var art = new Article
            {
                Id = Guid.Empty,
                Slug = slug,
                Title = "My first article",
                Description = "lalalalalalal",
                Body = "hjdjdhdjsdjjsdjhds dsjdsjkdsjksd",
                TagList = new[] { "hello", "world" },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AuthorId = Guid.Empty
            };
            return Task.FromResult(art);
        }

        public Task<Article[]> GetArticlesByAuthorIdAsync(Guid authorGuid)
        {
            var art = new Article
            {
                Id = Guid.Empty,
                Slug = "article-three",
                Title = "My first article",
                Description = "lalalalalalal",
                Body = "hjdjdhdjsdjjsdjhds dsjdsjkdsjksd",
                TagList = new[] { "hello", "world" },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AuthorId = authorGuid
            };
            return Task.FromResult(new[] { art });
        }
    }
}
