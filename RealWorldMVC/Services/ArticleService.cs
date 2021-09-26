using System;
using System.Threading.Tasks;
using RealWorldMVC.Models;
using System.Linq;
using RealWorldMVC.Data;
using Microsoft.EntityFrameworkCore;
using Slugify;

namespace RealWorldMVC.Services
{
    public class ArticleService : IArticleService
    {
        private SlugHelper slugHelper = new SlugHelper();
        private readonly ApplicationDbContext _context;
        public ArticleService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Article[]> GetArticlesAsync()
        {
            return await _context.Articles.ToArrayAsync();
        }

        public async Task<Article> GetArticleBySlugAsync(string slug)
        {
            return await _context.Articles.Where(a => a.Slug == slug).SingleAsync();
        }

        public async Task<Article[]> GetArticlesByAuthorIdAsync(Guid authorGuid)
        {
            return await _context.Articles.Where(a => a.AuthorId == authorGuid).ToArrayAsync();

        }

        public async Task<Article[]> GetArticlesByAuthorUsernameAsync(string username)
        {
            return await _context.Articles.Where(a => a.Author.Username == username).ToArrayAsync();
        }

        public async Task<bool> CreateArticleAsync(Article article)
        {
            var now = DateTime.Now;
            article.Id = Guid.NewGuid();
            article.CreatedAt = now;
            article.UpdatedAt = now;
            article.AuthorId = Guid.Empty;
            article.Slug = slugHelper.GenerateSlug(article.Title);
            _context.Articles.Add(article);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
