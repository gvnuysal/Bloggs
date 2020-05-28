using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleTags.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bloggs.ArticleTags
{
    public class ArticleTagAppService : AsyncCrudAppService<ArticleTag, ArticleTagDto, long, PagedArticleTagResultRequestDto, CreateArticleTagDto, CreateArticleTagDto>
    {
        public ArticleTagAppService(IRepository<ArticleTag, long> repository) : base(repository)
        {
        }
        protected override IQueryable<ArticleTag> CreateFilteredQuery(PagedArticleTagResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Article)
                .Include(x => x.Tag)
                .Include(x => x.Article.Author)
                .Include(x => x.Article.Category)
                .Include(x => x.Article.Author.User)
                .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId)
                .WhereIf(input.TagId > 0, x => x.TagId == input.TagId);
        }
    }
}
