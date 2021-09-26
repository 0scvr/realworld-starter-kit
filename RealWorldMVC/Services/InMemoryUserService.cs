using System;
using System.Threading.Tasks;
using RealWorldMVC.Models;

namespace RealWorldMVC.Services
{
    public class InMemoryUserService : IUserService
    {
        public InMemoryUserService()
        {
        }

        public Task<Article[]> GetUserArticlesByUsernameAsync(string username)
        {
            var art1 = new Article
            {
                Id = Guid.Empty,
                Slug = "article-one",
                Title = "My first article",
                Description = "lalalalalalal",
                Body = "hjdjdhdjsdjjsdjhds dsjdsjkdsjksd",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AuthorId = Guid.Empty
            };
            var art2 = new Article
            {
                Id = Guid.Empty,
                Slug = "article-two",
                Title = "My second article",
                Description = "lalalalalalal",
                Body = "hjdjdhdjsdjjsdjhds dsjdsjkdsjksd",
                CreatedAt = DateTime.Now.AddHours(-1),
                UpdatedAt = DateTime.Now.AddHours(-1),
                AuthorId = Guid.Empty
            };

            return Task.FromResult(new[] { art1, art2 });
        }

        public Task<User> GetUserByIdAsync(Guid guid)
        {
            var user = new User
            {
                Id = guid,
                Email = "kkk@kksk.ccc",
                Username = "oscar",
                Password = "kdkdkdkd",
                Bio = "allalalalalal alal",
                Image = "https://via.placeholder.com/150",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return Task.FromResult(user);
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            var user = new User
            {
                Id = Guid.Empty,
                Email = "kkk@kksk.ccc",
                Username = username,
                Password = "kdkdkdkd",
                Bio = "my bio goes here!",
                Image = "https://via.placeholder.com/150",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return Task.FromResult(user);
        }

        public Task<Comment[]> GetUserCommentsByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User[]> GetUsersAsync()
        {
            var user1 = new User
            {
                Id = Guid.Empty,
                Email = "kkk@kksk.ccc",
                Username = "oscar",
                Password = "kdkdkdkd",
                Bio = "allalalalalal alal",
                Image = "https://via.placeholder.com/150",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var user2 = new User
            {
                Id = Guid.Empty,
                Email = "peter@gmail.ccc",
                Username = "peter",
                Password = "ieuhznsq",
                Bio = "allalalalalal alal",
                Image = "https://via.placeholder.com/150",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return Task.FromResult(new[] { user1, user2 });
        }
    }
}
