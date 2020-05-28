using Abp.Application.Services;
using Bloggs.ArticleComments.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleFollows
{
    public interface IArticleFollowAppService : IAsyncCrudAppService<ArticleFollowDto, long, PagedArticleFollowResultRequestDto, CreateArticleFollowDto, CreateArticleFollowDto>
    {
    }
}
