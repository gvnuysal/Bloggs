using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.Categories.Dto
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<DeleteCategoryDto, Category>();
        }

    }
}
