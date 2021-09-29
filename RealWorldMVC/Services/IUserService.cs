using System;
using System.Threading.Tasks;
using RealWorldMVC.Models;

namespace RealWorldMVC.Services
{
    public interface IUserService
    {
        Task<AppUser[]> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(Guid guid);
        Task<AppUser> GetUserByUsernameAsync(string username);
        //Task<Comment[]> GetUserCommentsByUsernameAsync(string username);
        Task<Article[]> GetUserArticlesByUsernameAsync(string username);

        //Task<bool> CreateArticleAsync(Article article);

    }
}
