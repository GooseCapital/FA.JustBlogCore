using AutoMapper;
using FA.JustBlogCore.API.Models.DTO;
using FA.JustBlogCore.Services.Model;

namespace FA.JustBlogCore.API.Mapping
{
    public class TagMapping : Profile
    {
        public TagMapping()
        {
            CreateMap<Tag, TagDTO>().ReverseMap();
        }
    }
}