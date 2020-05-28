using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleViews.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bloggs.ArticleViews
{
    public class ArticleViewAppService : AsyncCrudAppService<ArticleView, ArticleViewDto, long, PagedArticleViewResultRequestDto, CreateArticleViewDto, CreateArticleViewDto>, IArticleViewAppService
    {
        public ArticleViewAppService(IRepository<ArticleView, long> repository) : base(repository)
        {
        }
        protected override IQueryable<ArticleView> CreateFilteredQuery(PagedArticleViewResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Article)
                .Include(x => x.Article.Author)
                .Include(x => x.Article.Category)
                .Include(x => x.Article.Author.User)
                .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId);
        }
    }
}
