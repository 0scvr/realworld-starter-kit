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
            return await _context.Articles.Where(a => a.Author.UserName == username).ToArrayAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(Guid guid)
        {
            return await _context.AppUsers.Where(u => u.Id == guid).SingleAsync();
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.AppUsers.Where(u => u.UserName == username).SingleAsync();
        }


        public async Task<AppUser[]> GetUsersAsync()
        {
            return await _context.AppUsers.ToArrayAsync();
        }
    }
}
