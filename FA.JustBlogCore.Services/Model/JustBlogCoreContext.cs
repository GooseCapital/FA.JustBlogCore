using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.JustBlogCore.Services.Model
{
    public class JustBlogCoreContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TIENDUNG\SQLEXPRESS;Database=JustBlogCore;User Id=sa;Password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>().HasMany(n => n.Posts).WithMany(n => n.Tags).UsingEntity(n =>
            {
                n.ToTable("PostTagMap");
            });
        }
    }
}