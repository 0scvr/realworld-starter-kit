using System;
using System.Threading.Tasks;
using RealWorld.Models;

namespace RealWorld.Services;
public class InMemoryCommentService : ICommentService
{
    public InMemoryCommentService()
    {
    }

    public Task<Comment[]> GetCommentsAsync()
    {
        var com1 = new Comment
        {
            Id = Guid.Empty,
            Body = "goodbye !",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AuthorId = Guid.Empty,
            ArticleId = Guid.Empty,
        };
        var com2 = new Comment
        {
            Id = Guid.Empty,
            Body = "Hello world",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AuthorId = Guid.Empty,
            ArticleId = Guid.Empty,
        };
        return Task.FromResult(new[] { com1, com2 });
    }

    public Task<Comment[]> GetCommentsByArticleIdAsync(Guid articleGuid)
    {
        var com1 = new Comment
        {
            Id = Guid.Empty,
            Body = "goodbye !",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AuthorId = Guid.Empty,
            ArticleId = articleGuid,
        };
        var com2 = new Comment
        {
            Id = Guid.Empty,
            Body = "Hello world",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AuthorId = Guid.Empty,
            ArticleId = articleGuid,
        };
        return Task.FromResult(new[] { com1, com2 });
    }

    public Task<Comment[]> GetCommentsByAuthorIdAsync(Guid authorGuid)
    {
        var com1 = new Comment
        {
            Id = Guid.Empty,
            Body = "goodbye !",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AuthorId = authorGuid,
            ArticleId = Guid.Empty,
        };
        var com2 = new Comment
        {
            Id = Guid.Empty,
            Body = "Hello world",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AuthorId = authorGuid,
            ArticleId = Guid.Empty,
        };
        return Task.FromResult(new[] { com1, com2 });
    }
}
