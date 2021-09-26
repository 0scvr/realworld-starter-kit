using System;
using System.Threading.Tasks;
using RealWorldMVC.Models;

namespace RealWorldMVC.Services
{
    public interface IArticleService
    {
        Task<Article[]> GetArticlesAsync();
        Task<Article> GetArticleBySlugAsync(string slug);
        Task<Article[]> GetArticlesByAuthorIdAsync(Guid authorGuid);
        Task<Article[]> GetArticlesByAuthorUsernameAsync(string username);

        Task<bool> CreateArticleAsync(Article article);
    }
}
