using System;
using System.Threading.Tasks;
using RealWorldMVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RealWorldMVC.Data;

namespace RealWorldMVC.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Article[]> GetUserArticlesByUsernameAsync(string username)
        {
            return await _context.Articles.Where(a => a.Author.Username == username).ToArrayAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid guid)
        {
            return await _context.AppUsers.Where(u => u.Id == guid).SingleAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.AppUsers.Where(u => u.Username == username).SingleAsync();
        }


        public async Task<User[]> GetUsersAsync()
        {
            return await _context.AppUsers.ToArrayAsync();
        }
    }
}
