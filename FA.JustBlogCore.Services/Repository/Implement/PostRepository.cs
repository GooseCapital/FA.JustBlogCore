using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using FA.JustBlogCore.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Implement
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }

        public override void Add(Post entity)
        {
            entity.UrlSlug = GenerateSlug(entity.Title);
            base.Add(entity);
        }

        public int CountPostForCategory(string category)
        {
            return this.GetPostByCategory(category).Count;
        }

        public int CountPostForTag(string tag)
        {
            return this.GetPostsByTag(tag).Count;
        }

        public Post Find(int year, int month, string urlSlug)
        {
            return this.Find(n => n.PostedOn.Year == year && n.PostedOn.Month == month && n.UrlSlug == urlSlug && n.Published)
                .Include(n => n.Tags).Include(n => n.Category).FirstOrDefault();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return this.Find(n => n.Published).OrderByDescending(n => n.Rate)
                .Include(n => n.Tags).Include(n => n.Category).Take(size).ToList();
        }

        public IList<Post> GetHighestPosts()
        {
            return this.Find(n => n.Published).OrderByDescending(n => n.Rate)
                .Include(n => n.Tags).Include(n => n.Category).ToList();
        }

        public IList<Post> GetLastestPost(int size)
        {
            return this.Find(n => n.Published).OrderByDescending(n => n.PostedOn)
                .Include(n => n.Tags).Include(n => n.Category).Take(size).ToList();
        }

        public IList<Post> GetLastestPost()
        {
            return this.Find(n => n.Published).OrderByDescending(n => n.PostedOn)
                .Include(n => n.Tags).Include(n => n.Category).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return this.Find(n => n.Published).OrderByDescending(n => n.ViewCount)
                .Include(n => n.Tags).Include(n => n.Category).Take(size).ToList();
        }

        public IList<Post> GetMostViewedPost()
        {
            return this.Find(n => n.Published).OrderByDescending(n => n.ViewCount)
                .Include(n => n.Tags).Include(n => n.Category).ToList();
        }

        public IList<Post> GetPostByCategory(string category)
        {
            return this.Find(n => n.Category.UrlSlug == category && n.Published)
                .Include(n => n.Tags).Include(n => n.Category).OrderByDescending(n => n.PostedOn).ToList();
        }

        public IList<Post> GetPostsByMonth(int month, int year)
        {
            return this.Find(n => n.PostedOn.Year == year && n.PostedOn.Month == month && n.Published)
                .Include(n => n.Tags).Include(n => n.Category).OrderByDescending(n => n.PostedOn).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return this.Find(n => n.Tags.Any(n => n.UrlSlug == tag) && n.Published).OrderByDescending(n => n.PostedOn)
                .Include(n => n.Tags).Include(n => n.Category).ToList();
        }

        public IList<Post> GetPublishedPost()
        {
            return this.Find(n => n.Published).OrderByDescending(n => n.PostedOn)
                .Include(n => n.Tags).Include(n => n.Category).ToList();
        }

        public IList<Post> GetUnpublishedPost()
        {
            return this.Find(n => !n.Published).OrderByDescending(n => n.PostedOn)
                .Include(n => n.Tags).Include(n => n.Category).ToList();
        }

        public override void Update(Post entity)
        {
            entity.UrlSlug = GenerateSlug(entity.Title);
            base.Update(entity);
        }

        private string GenerateSlug(string name)
        {
            var currentSlug = this.Find(n => n.UrlSlug.Contains(name.GenerateSlug()))
                .Select(n => n.UrlSlug).OrderByDescending(n => n).ToList();

            return name.GenerateSlugNotDuplicate(currentSlug);
        }
    }
}