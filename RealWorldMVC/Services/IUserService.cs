using System;
using System.Threading.Tasks;
using RealWorldMVC.Models;

namespace RealWorldMVC.Services
{
    public interface IUserService
    {
        Task<User[]> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid guid);
        Task<User> GetUserByUsernameAsync(string username);
        Task<Comment[]> GetUserCommentsByUsernameAsync(string username);
        Task<Article[]> GetUserArticlesByUsernameAsync(string username);
    }
}
