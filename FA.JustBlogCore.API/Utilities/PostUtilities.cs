using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlogCore.API.Utilities
{
    public static class PostUtilities
    {
        public static bool InsertTagsInPost(IUnitOfWork unitOfWork, Post post, IList<Guid> tagsGuid)
        {
            foreach (var tagId in tagsGuid)
            {
                var tag = unitOfWork.TagRepository.Find(tagId);
                if (tag == null)
                {
                    return false;
                }

                post.Tags.Add(tag);
            }

            return true;
        }

        public static bool InsertCommentsInPost(IUnitOfWork unitOfWork, Post post, IList<Guid> commentsGuid)
        {
            foreach (var commentId in commentsGuid)
            {
                var comment = unitOfWork.CommentRepository.Find(commentId);
                if (comment == null)
                {
                    return false;
                }

                post.Comments.Add(comment);
            }

            return true;
        }
    }
}