using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlogCore.Services.Model
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string PostContent { get; set; }

        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime Modified { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public string PostedBy { get; set; }

        public string ReviewedBy { get; set; }

        public virtual IList<Tag> Tags { get; set; }

        public virtual IList<Comment> Comments { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [NotMapped]
        public double Rate
        {
            get
            {
                if (this.RateCount == 0)
                {
                    return 0;
                }
                else
                {
                    return TotalRate * 1.0 / RateCount;
                }
            }
        }
    }
}