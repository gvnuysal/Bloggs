using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Bloggs.ArticleTags.Dto;
using Bloggs.Domain.Entities;
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
            return Repository.GetAll()
                .WhereIf(input.ArticleId > 0, x => x.ArticleId == input.ArticleId)
                .WhereIf(input.TagId > 0, x => x.TagId == input.TagId);
        }
    }
}
