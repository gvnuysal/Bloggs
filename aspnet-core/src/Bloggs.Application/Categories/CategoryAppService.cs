using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Bloggs.Authorization;
using Bloggs.Categories.Dto;
using Bloggs.Domain.Entities;
using System.Linq;

namespace Bloggs.Categories
{
    //[AbpAuthorize(PermissionNames.Pages_Categories)]
    public class CategoryAppService : AsyncCrudAppService<Category,CategoryDto,long,PagedCategoryResultRequestDto,CreateCategoryDto,CreateCategoryDto,CategoryDto,CategoryDto>, ICategoryAppService
    {
        public CategoryAppService(IRepository<Category,long> repository):base(repository)
        {

        }
        protected override IQueryable<Category> CreateFilteredQuery(PagedCategoryResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.ToLower().Contains(input.Keyword.Trim().ToLower()));
        }
    }
}
