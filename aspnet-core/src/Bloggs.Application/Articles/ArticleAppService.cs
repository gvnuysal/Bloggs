using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Bloggs.Articles.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.Articles
{
    public class ArticleAppService : AsyncCrudAppService<Article, ArticleDto, long, PagedArticleResultRequestDto, CreateArticleDto, UpdateArticleDto>, IArticleAppService
    {
        private readonly IRepository<Article, long> _repository;

        public ArticleAppService(IRepository<Article, long> repository) : base(repository)
        {
            _repository = repository;
        }

        public override Task<PagedResultDto<ArticleDto>> GetAllAsync(PagedArticleResultRequestDto input)
        {
            var articles = _repository.GetAll()
                                      .Include(x => x.Author)
                                      .Include(x => x.Author.User)
                                      .Include(x => x.Category)
                                      .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Contents.ToLower().Contains(input.Keyword.Trim().ToLower())
                                      || x.Title.ToLower().Contains(input.Keyword.Trim().ToLower()))
                                      .WhereIf(input.AuthorId > 0, x => x.AuthorId == input.AuthorId)
                                      .WhereIf(input.CategoryId > 0, x => x.CategoryId == input.CategoryId)
                                      .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive)
                                      .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted)
                                      .ToList();

            var value = ObjectMapper.Map<List<ArticleDto>>(articles);

            return Task.FromResult(new PagedResultDto<ArticleDto> { Items = value, TotalCount = value.Count() });
        }

        public async Task<GetArticleUpdateOutput> GetArticleForUpdate(EntityDto input)
        {
            var article = await Repository.GetAsync(input.Id);
            var updateArticleDto = ObjectMapper.Map<UpdateArticleDto>(article);

            return new GetArticleUpdateOutput { Article = updateArticleDto };
        }
    }
}
