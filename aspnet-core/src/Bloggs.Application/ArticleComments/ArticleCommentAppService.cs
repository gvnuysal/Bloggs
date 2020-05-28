using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Bloggs.ArticleComments.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggs.ArticleComments
{
    public class ArticleCommentAppService : AsyncCrudAppService<ArticleComment, ArticleCommentDto, long, PagedArticleCommentResultRequestDto, CreateArticleCommentDto, CreateArticleCommentDto>, IArticleCommentAppService
    {
        public ArticleCommentAppService(IRepository<ArticleComment, long> repository) : base(repository)
        {

        }
        protected override IQueryable<ArticleComment> CreateFilteredQuery(PagedArticleCommentResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Article)
                .Include(x => x.Article.Author)
                .Include(x => x.Article.Category)
                .Include(x => x.Article.Author.User)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Comment.ToLower().Contains(input.Keyword.Trim().ToLower()))
                .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId)
                .Where(x => x.IsAccept);
        }
    }
}
