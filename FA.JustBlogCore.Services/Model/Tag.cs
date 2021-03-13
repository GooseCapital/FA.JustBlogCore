using System.Collections.Generic;
using System.Text;

namespace FA.JustBlogCore.Services.Model
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}