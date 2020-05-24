using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Bloggs.Categories.Dto;
using Bloggs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bloggs.Categories
{
    public interface ICategoryAppService:IApplicationService
    {
        Task<List<CategoryDto>> GetAll(CategoryDto input);
        Task<CategoryDto> CreateCategory(CreateCategoryDto input);
    }

}
