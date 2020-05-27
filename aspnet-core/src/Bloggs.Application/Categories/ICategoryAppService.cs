using Abp.Application.Services;
using Bloggs.Categories.Dto;

namespace Bloggs.Categories
{
    public interface ICategoryAppService:IAsyncCrudAppService<CategoryDto,long,PagedCategoryResultRequestDto,CreateCategoryDto,CreateCategoryDto,CategoryDto,CategoryDto>
    {

    }

}
