using Abp.Application.Services;
using Abp.Domain.Repositories;
using Bloggs.ArticleComments.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleFollows
{
    public class ArticleFollowAppService : AsyncCrudAppService<ArticleFollow, ArticleFollowDto, long, PagedArticleFollowResultRequestDto, CreateArticleFollowDto, CreateArticleFollowDto>
    {
        public ArticleFollowAppService(IRepository<ArticleFollow, long> repository) : base(repository)
        {
        }
    }
}
