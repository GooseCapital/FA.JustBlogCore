using AutoMapper;
using FA.JustBlogCore.API.Models.DTO;
using FA.JustBlogCore.Services.Model;

namespace FA.JustBlogCore.API.Mapping
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, CommentDTO>().ReverseMap();
        }
    }
}