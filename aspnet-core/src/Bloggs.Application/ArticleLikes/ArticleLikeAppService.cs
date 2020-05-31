using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleLikes.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.ArticleLikes
{
    public class ArticleLikeAppService : AsyncCrudAppService<ArticleLike, ArticleLikeDto, long, PagedArticleLikeResultRequestDto, CreateArticleLikeDto, CreateArticleLikeDto>, IArticleLikeAppService
    {
        private readonly IRepository<ArticleLike, long> _repository;
        public ArticleLikeAppService(IRepository<ArticleLike, long> repository) : base(repository)
        {
            _repository = repository;
        }
        public override Task<PagedResultDto<ArticleLikeDto>> GetAllAsync(PagedArticleLikeResultRequestDto input)
        {
            var articleFollows = _repository.GetAllIncluding(x => x.Article)
                                     .Include(x => x.Article.Author)
                                     .Include(x => x.Article.Category)
                                     .Include(x => x.Article.Author.User)
                                     .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId)
                                     .WhereIf(!input.IsDeleted.HasValue, x => x.IsDeleted == false)
                                     .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted).ToList();

            var value = ObjectMapper.Map<List<ArticleLikeDto>>(articleFollows);

            return Task.FromResult(new PagedResultDto<ArticleLikeDto> { Items = value, TotalCount = value.Count() });
        }
    }
}
