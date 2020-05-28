using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleLikes.Dto;
using Bloggs.Authorization.Users;
using Bloggs.Domain.Entities;
using Bloggs.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bloggs.ArticleLikes
{
    public class ArticleLikeAppService : AsyncCrudAppService<ArticleLike, ArticleLikeDto, long, PagedArticleLikeResultRequestDto, CreateArticleLikeDto, CreateArticleLikeDto>, IArticleLikeAppService
    {
        public ArticleLikeAppService(IRepository<ArticleLike, long> repository) : base(repository)
        {
        }
        protected override IQueryable<ArticleLike> CreateFilteredQuery(PagedArticleLikeResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Article)
                .Include(x => x.Article.Category)
                .Include(x => x.Article.Author)
                .Include(x => x.Article.Author.User)
                .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId);
        }
    }
}
