using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.JustBlogCore.Services.Model
{
    public class JustBlogCoreContext : DbContext
    {
        public JustBlogCoreContext(DbContextOptions<JustBlogCoreContext> options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=TIENDUNG\SQLEXPRESS;Database=JustBlogCore;User Id=sa;Password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>().HasMany(n => n.Posts).WithMany(n => n.Tags).UsingEntity(n =>
            {
                n.ToTable("PostTagMap");
            });

            AddSeedData(modelBuilder);
        }

        public static void AddSeedData(ModelBuilder context)
        {
            IList<Category> categoriesList = new List<Category>()
            {
                new Category() { Id = Guid.NewGuid(), Name = "Thời sự", UrlSlug = "thoi-su" },
                new Category() { Id = Guid.NewGuid(), Name = "Góc nhìn", UrlSlug = "goc-nhin" },
                new Category() { Id = Guid.NewGuid(), Name = "Thế giới", UrlSlug = "the-gioi" },
                new Category() { Id = Guid.NewGuid(), Name = "Giáo dục", UrlSlug = "giao-duc" },
            };

            IList<Tag> tagList = new List<Tag>()
            {
                new Tag() { Id = Guid.NewGuid(), Name = "Giao thông", UrlSlug = "giao-thong" },
                new Tag() { Id = Guid.NewGuid(), Name = "Chính trị", UrlSlug = "chinh-tri" },
                new Tag() { Id = Guid.NewGuid(), Name = "Tuyến đầu chống dịch", UrlSlug = "tuyen-dau-chong-dich" },
                new Tag() { Id = Guid.NewGuid(), Name = "Tuyển sinh", UrlSlug = "tuyen-sinh" },
                new Tag() { Id = Guid.NewGuid(), Name = "Điểm thi", UrlSlug = "diem-thi" },
                new Tag() { Id = Guid.NewGuid(), Name = "Du học", UrlSlug = "du-hoc" },
                new Tag() { Id = Guid.NewGuid(), Name = "Học tiếng Anh", UrlSlug = "hoc-tieng-anh" },
                new Tag() { Id = Guid.NewGuid(), Name = "Trắc nghiệm", UrlSlug = "trac-nghiem" },
            };

            context.Entity<Category>().HasData(categoriesList);
            context.Entity<Tag>().HasData(tagList);
        }
    }
}