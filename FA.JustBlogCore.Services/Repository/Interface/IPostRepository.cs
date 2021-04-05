using FA.JustBlogCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Interface
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Post Find(int year, int month, string urlSlug);

        IList<Post> GetPublishedPost();

        IList<Post> GetUnpublishedPost();

        IList<Post> GetLastestPost(int size);

        IList<Post> GetLastestPost();

        IList<Post> GetPostsByMonth(int month, int year);

        int CountPostForCategory(string category);

        IList<Post> GetPostByCategory(string category);

        int CountPostForTag(string tag);

        IList<Post> GetPostsByTag(string tag);

        IList<Post> GetMostViewedPost(int size);

        IList<Post> GetMostViewedPost();

        IList<Post> GetHighestPosts(int size);

        IList<Post> GetHighestPosts();
    }
}