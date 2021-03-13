using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlogCore.Services.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}