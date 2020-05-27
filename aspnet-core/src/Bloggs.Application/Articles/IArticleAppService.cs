using Abp.Application.Services;
using Bloggs.Articles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Articles
{
    public interface IArticleAppService : IAsyncCrudAppService<ArticleDto, long, PagedArticleResultRequestDto, CreateArticleDto, CreateArticleDto>
    {
    }
}
