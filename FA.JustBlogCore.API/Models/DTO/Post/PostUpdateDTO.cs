using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlogCore.API.Models.DTO.Post
{
    public class PostUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string PostContent { get; set; }

        public bool Published { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public string PostedBy { get; set; }

        public string ReviewedBy { get; set; }

        public virtual IList<Guid> TagsGuid { get; set; }

        public virtual IList<Guid> CommentsGuid { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
    }
}