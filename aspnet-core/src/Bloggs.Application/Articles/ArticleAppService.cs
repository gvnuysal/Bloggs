using Abp.Application.Services;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Bloggs.Articles.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bloggs.Articles
{
    public class ArticleAppService : AsyncCrudAppService<Article, ArticleDto, long, PagedArticleResultRequestDto, CreateArticleDto, CreateArticleDto>, IArticleAppService
    {

        public ArticleAppService(IRepository<Article, long> repository) : base(repository)
        {
        }
    }
}
