using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Bloggs.Authorization;
using Bloggs.Categories.Dto;
using Bloggs.Domain.Entities;

namespace Bloggs.Categories
{
    //[AbpAuthorize(PermissionNames.Pages_Categories)]
    public class CategoryAppService : AsyncCrudAppService<Category,CategoryDto,long,PagedCategoryResultRequestDto,CreateCategoryDto,CreateCategoryDto,CategoryDto,CategoryDto>, ICategoryAppService
    {
        public CategoryAppService(IRepository<Category,long> repository):base(repository)
        {
       
        }

    }
}
