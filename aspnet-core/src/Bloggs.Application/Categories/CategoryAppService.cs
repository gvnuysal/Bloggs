using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Bloggs.Categories.Dto;
using Bloggs.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.Categories
{
    //[AbpAuthorize(PermissionNames.Pages_Categories)]
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, long, PagedCategoryResultRequestDto, CreateCategoryDto, UpdateCategoryDto, CategoryDto, DeleteCategoryDto>, ICategoryAppService
    {
        private readonly IRepository<Article, long> _articleRepository;
        public CategoryAppService(IRepository<Category, long> repository, IRepository<Article, long> articleRepository) : base(repository)
        {
            LocalizationSourceName = BloggsConsts.LocalizationSourceName;
            _articleRepository = articleRepository;
        }
        protected override IQueryable<Category> CreateFilteredQuery(PagedCategoryResultRequestDto input)
        {
            return Repository.GetAll()
                             .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.ToLower().Contains(input.Keyword.Trim().ToLower()) ||
                                                                                x.Description.ToLower().Contains(input.Keyword.Trim().ToLower()))
                             .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive)
                             .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted);
        }
        public override async Task DeleteAsync(DeleteCategoryDto input)
        {
            var getArticleCountByCategoryId = await _articleRepository.GetAllListAsync(x => x.IsActive && !x.IsDeleted && x.CategoryId == input.Id);
            if (getArticleCountByCategoryId.Count() > 0)
                throw new UserFriendlyException(L("ErrorTitle"), L("UsingCategory"));

            await base.DeleteAsync(input);
        }

        public async Task<GetCategoryUpdateOutput> GetCategoryForUpdate(EntityDto input)
        {
            var category = await Repository.GetAsync(input.Id);
            var updateCategoryDto = ObjectMapper.Map<UpdateCategoryDto>(category);

            return new GetCategoryUpdateOutput { Category = updateCategoryDto };
        }
    }
}
