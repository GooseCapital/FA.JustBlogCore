using System;
using System.Collections.Generic;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; set; }

        ICategoryRepository CategoryRepository { get; set; }

        ICommentRepository CommentRepository { get; set; }

        ITagRepository TagRepository { get; set; }

        int SaveChanges();
    }
}