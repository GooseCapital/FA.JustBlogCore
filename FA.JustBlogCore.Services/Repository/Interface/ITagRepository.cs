using FA.JustBlogCore.Services.Model;

namespace FA.JustBlogCore.Services.Repository.Interface
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Tag Find(string urlSlug);
    }
}