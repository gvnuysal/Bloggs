using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleLikes.Dto;
using Bloggs.Domain.Entities;
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
            return Repository.GetAll()
                .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId);
        }
    }
}
