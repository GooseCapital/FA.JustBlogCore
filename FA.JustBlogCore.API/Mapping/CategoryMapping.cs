using AutoMapper;
using FA.JustBlogCore.API.Models.DTO;
using FA.JustBlogCore.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlogCore.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}