using FA.JustBlogCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlogCore.Services.Repository.Interface
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        void Add(Guid postId, string commentName, string commentEmail, string commentTitle, string commentBody);

        IList<Comment> GetCommentsForPost(Guid postId);
    }
}