using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Implement;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustBlog.Test
{
    [TestFixture]
    public class PostTest
    {
        private DbContextOptions<JustBlogCoreContext> options = new DbContextOptionsBuilder<JustBlogCoreContext>()
                .UseInMemoryDatabase(databaseName: "JustBlogCore").Options;

        [TestCase("Test", "This is description")]
        public void Add(string name, string description)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new JustBlogCoreContext(options));
            unitOfWork.CategoryRepository.Add(new Category()
            {
                Name = name,
                Description = description
            });

            unitOfWork.SaveChanges();
            unitOfWork.CategoryRepository.Add(new Category()
            {
                Name = name,
                Description = description
            });

            unitOfWork.SaveChanges();
            unitOfWork.CategoryRepository.Add(new Category()
            {
                Name = name,
                Description = description
            });

            unitOfWork.SaveChanges();
            var a = unitOfWork.CategoryRepository.GetAll().ToList();
        }
    }
}