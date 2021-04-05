using FA.JustBlogCore.API.Models.DTO.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlogCore.API.Models.DTO
{
    public class CommentDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string CommentHeader { get; set; }

        [Required]
        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }

        public Guid PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual PostDTO Post { get; set; }
    }
}