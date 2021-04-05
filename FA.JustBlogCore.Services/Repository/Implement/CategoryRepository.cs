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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public override void Add(Category entity)
        {
            entity.UrlSlug = GenerateSlug(entity.Name);

            base.Add(entity);
        }

        public override void Update(Category entity)
        {
            entity.UrlSlug = GenerateSlug(entity.Name);

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