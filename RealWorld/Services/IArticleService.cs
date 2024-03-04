using System;
using System.Threading.Tasks;
using RealWorld.Models;

namespace RealWorld.Services;
public interface IArticleService
{
    Task<Article[]> GetArticlesAsync();
    Task<Article> GetArticleBySlugAsync(string slug);
    Task<Article[]> GetArticlesByAuthorIdAsync(Guid authorGuid);
}
