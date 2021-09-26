using System;
using System.Threading.Tasks;
using RealWorldMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RealWorldMVC.Data;

namespace RealWorldMVC.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Comment[]> GetCommentsAsync()
        {
            return await _context.Comments.ToArrayAsync();
        }

        public async Task<Comment[]> GetCommentsByArticleIdAsync(Guid articleGuid)
        {
            return await _context.Comments.Where(c => c.ArticleId == articleGuid).ToArrayAsync();

        }

        public async Task<Comment[]> GetCommentsByAuthorIdAsync(Guid authorGuid)
        {
            return await _context.Comments.Where(c => c.AuthorId == authorGuid).ToArrayAsync();

        }
    }
}
