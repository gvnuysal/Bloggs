using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleViews.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.ArticleViews
{
    public class ArticleViewAppService : AsyncCrudAppService<ArticleView, ArticleViewDto, long, PagedArticleViewResultRequestDto, CreateArticleViewDto, CreateArticleViewDto>, IArticleViewAppService
    {
        private readonly IRepository<ArticleView, long> _repository;
        public ArticleViewAppService(IRepository<ArticleView, long> repository) : base(repository)
        {
            _repository = repository;
        }
        public override Task<PagedResultDto<ArticleViewDto>> GetAllAsync(PagedArticleViewResultRequestDto input)
        {
            var articleFollows = _repository.GetAllIncluding(x => x.Article)
                                     .Include(x => x.Article.Author)
                                     .Include(x => x.Article.Category)
                                     .Include(x => x.Article.Author.User)
                                     .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId)
                                     .WhereIf(!input.IsDeleted.HasValue, x => x.IsDeleted == false)
                                     .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted).ToList();

            var value = ObjectMapper.Map<List<ArticleViewDto>>(articleFollows);

            return Task.FromResult(new PagedResultDto<ArticleViewDto> { Items = value, TotalCount = value.Count() });
        }
    }
}
