using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Bloggs.Categories.Dto;
using System.Threading.Tasks;

namespace Bloggs.Categories
{
    public interface ICategoryAppService:IAsyncCrudAppService<CategoryDto,long,PagedCategoryResultRequestDto,CreateCategoryDto,UpdateCategoryDto,CategoryDto,DeleteCategoryDto>
    {
        Task<GetCategoryUpdateOutput> GetCategoryForUpdate(EntityDto input);
    }

}
