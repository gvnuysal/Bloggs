using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleComments.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bloggs.ArticleFollows
{
    public class ArticleFollowAppService : AsyncCrudAppService<ArticleFollow, ArticleFollowDto, long, PagedArticleFollowResultRequestDto, CreateArticleFollowDto, CreateArticleFollowDto>,IArticleFollowAppService
    {
        public ArticleFollowAppService(IRepository<ArticleFollow, long> repository) : base(repository)
        {
        }
        protected override IQueryable<ArticleFollow> CreateFilteredQuery(PagedArticleFollowResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Article)
                .Include(x => x.Article.Author)
                .Include(x => x.Article.Category)
                .Include(x => x.Article.Author.User)
                .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId);
        }
    }
}
