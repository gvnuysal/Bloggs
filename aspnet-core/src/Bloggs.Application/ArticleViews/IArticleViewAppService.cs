using Abp.Application.Services;
using Bloggs.ArticleViews.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleViews
{
    public interface IArticleViewAppService : IAsyncCrudAppService<ArticleViewDto, long, PagedArticleViewResultRequestDto, CreateArticleViewDto, CreateArticleViewDto>
    {
    }
}
