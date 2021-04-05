using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FA.JustBlogCore.Services.Repository.Implement
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

        public void Add(Guid postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            Comment comment = new Comment()
            {
                PostId = postId,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                Name = commentName
            };

            this.Add(comment);
        }

        public override void Add(Comment entity)
        {
            entity.CommentTime = DateTime.Now;
            base.Add(entity);
        }

        public IList<Comment> GetCommentsForPost(Guid postId)
        {
            return this.Find(n => n.PostId == postId).Include(n => n.Post).ToList();
        }
    }
}