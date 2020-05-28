using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleComments.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bloggs.ArticleFollows
{
    public class ArticleFollowAppService : AsyncCrudAppService<ArticleFollow, ArticleFollowDto, long, PagedArticleFollowResultRequestDto, CreateArticleFollowDto, CreateArticleFollowDto>
    {
        public ArticleFollowAppService(IRepository<ArticleFollow, long> repository) : base(repository)
        {
        }
        protected override IQueryable<ArticleFollow> CreateFilteredQuery(PagedArticleFollowResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId);
        }
    }
}
