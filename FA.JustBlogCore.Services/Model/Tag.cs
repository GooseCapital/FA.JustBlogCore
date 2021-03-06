using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FA.JustBlogCore.Services.Model
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}