using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Bloggs.ArticleFollows.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.ArticleFollows
{
    public class ArticleFollowAppService : AsyncCrudAppService<ArticleFollow, ArticleFollowDto, long, PagedArticleFollowResultRequestDto, CreateArticleFollowDto, CreateArticleFollowDto>, IArticleFollowAppService
    {
        private readonly IRepository<ArticleFollow, long> _repository;
        public ArticleFollowAppService(IRepository<ArticleFollow, long> repository) : base(repository)
        {
            _repository = repository;
        }
        public override Task<PagedResultDto<ArticleFollowDto>> GetAllAsync(PagedArticleFollowResultRequestDto input)
        {
            var articleFollows = _repository.GetAllIncluding(x => x.Article)
                                     .Include(x => x.Article.Author)
                                     .Include(x => x.Article.Category)
                                     .Include(x => x.Article.Author.User)
                                     .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId)
                                     .WhereIf(!input.IsDeleted.HasValue, x => x.IsDeleted == false)
                                     .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted).ToList();

            var value = ObjectMapper.Map<List<ArticleFollowDto>>(articleFollows);

            return Task.FromResult(new PagedResultDto<ArticleFollowDto> { Items = value, TotalCount = value.Count() });
        }
    }
}
