using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Bloggs.ArticleComments.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.ArticleComments
{
    public class ArticleCommentAppService : AsyncCrudAppService<ArticleComment, ArticleCommentDto, long, PagedArticleCommentResultRequestDto, CreateArticleCommentDto, UpdateArticleCommentDto>, IArticleCommentAppService
    {
        private readonly IRepository<ArticleComment, long> _repository;
        public ArticleCommentAppService(IRepository<ArticleComment, long> repository) : base(repository)
        {
            _repository = repository;
        }

        public override Task<PagedResultDto<ArticleCommentDto>> GetAllAsync(PagedArticleCommentResultRequestDto input)
        {
            var articleComments = _repository.GetAllIncluding(x => x.Article)
                                     .Include(x => x.Article.Author)
                                     .Include(x => x.Article.Category)
                                     .Include(x => x.Article.Author.User)
                                     .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Comment.ToLower().Contains(input.Keyword.Trim().ToLower()))
                                     .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId)
                                     .WhereIf(input.IsAccept.HasValue, x => x.IsAccept == input.IsAccept)
                                     .WhereIf(!input.IsDeleted.HasValue, x => x.IsDeleted == false)
                                     .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted).ToList();

            var value = ObjectMapper.Map<List<ArticleCommentDto>>(articleComments);

            return Task.FromResult(new PagedResultDto<ArticleCommentDto> { Items = value, TotalCount = value.Count() });
        }
    }
}
