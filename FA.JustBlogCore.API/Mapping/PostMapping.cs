using AutoMapper;
using FA.JustBlogCore.API.Models.DTO.Post;
using FA.JustBlogCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlogCore.API.Mapping
{
    public class PostMapping : Profile
    {
        public PostMapping()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Post, PostCreateDTO>().ReverseMap();
        }
    }
}