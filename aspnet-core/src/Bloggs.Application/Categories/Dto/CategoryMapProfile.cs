using AutoMapper;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Categories.Dto
{
    public class CategoryMapProfile:Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>();
        }

    }
}
