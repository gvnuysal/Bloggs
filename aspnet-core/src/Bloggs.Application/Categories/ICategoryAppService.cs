using Abp.Application.Services;
using Abp.Domain.Repositories;
using Bloggs.Categories.Dto;
using Bloggs.Domain.Entities;

namespace Bloggs.Categories
{
    public interface ICategoryAppService:IAsyncCrudAppService<CategoryDto,long,PagedCategoryResultRequestDto,CategoryDto,CategoryDto>
    {

    }

}
