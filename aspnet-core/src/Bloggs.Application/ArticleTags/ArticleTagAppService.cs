using Abp.Application.Services;
using Abp.Domain.Repositories;
using Bloggs.ArticleTags.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleTags
{
    public class ArticleTagAppService : AsyncCrudAppService<ArticleTag, ArticleTagDto, long, PagedArticleTagResultRequestDto, CreateArticleTagDto, CreateArticleTagDto>
    {
        public ArticleTagAppService(IRepository<ArticleTag, long> repository) : base(repository)
        {
        }
    }
}
