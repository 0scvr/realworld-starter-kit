using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealWorldMVC.Models;

namespace RealWorldMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,IdentityRole<Guid>,Guid>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Article>()
        //        .Property(b => b.CreatedAt)
        //        .HasDefaultValueSql("datetime()");
        //}
    }
}
