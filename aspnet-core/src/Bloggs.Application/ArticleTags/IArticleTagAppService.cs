using Abp.Application.Services;
using Bloggs.ArticleTags.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleTags
{
    public interface IArticleTagAppService : IAsyncCrudAppService<ArticleTagDto, long, PagedArticleTagResultRequestDto, CreateArticleTagDto, CreateArticleTagDto>
    {
    }
}
