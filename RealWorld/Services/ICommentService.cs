using System;
using System.Threading.Tasks;
using RealWorld.Models;

namespace RealWorld.Services;
public interface ICommentService
{
    Task<Comment[]> GetCommentsAsync();
    Task<Comment[]> GetCommentsByAuthorIdAsync(Guid guid); // Returns all the comments for a user
    Task<Comment[]> GetCommentsByArticleIdAsync(Guid guid);  // Returns all the comments for an article
}
