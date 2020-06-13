using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleTags.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.ArticleTags
{
    public class ArticleTagAppService : AsyncCrudAppService<ArticleTag, ArticleTagDto, long, PagedArticleTagResultRequestDto, CreateArticleTagDto, UpdateArticleTagDto>
    {
        private readonly IRepository<ArticleTag, long> _repository;
        public ArticleTagAppService(IRepository<ArticleTag, long> repository) : base(repository)
        {
            _repository = repository;
        }
        public override Task<PagedResultDto<ArticleTagDto>> GetAllAsync(PagedArticleTagResultRequestDto input)
        {
            var articleFollows = _repository.GetAllIncluding(x => x.Article)
                                     .Include(x => x.Article.Author)
                                     .Include(x => x.Article.Category)
                                     .Include(x => x.Article.Author.User)
                                     .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId)
                                     .WhereIf(!input.IsDeleted.HasValue, x => x.IsDeleted == false)
                                     .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted)
                                     .Skip(input.SkipCount).Take(input.MaxResultCount)
                                     .ToList();

            var value = ObjectMapper.Map<List<ArticleTagDto>>(articleFollows);

            return Task.FromResult(new PagedResultDto<ArticleTagDto> { Items = value, TotalCount = value.Count() });
        }
    }
}
