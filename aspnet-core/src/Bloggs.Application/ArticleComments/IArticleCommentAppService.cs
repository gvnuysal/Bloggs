using Abp.Application.Services;
using Bloggs.ArticleComments.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleComments
{
    public interface IArticleCommentAppService : IAsyncCrudAppService<ArticleCommentDto, long, PagedArticleCommentResultRequestDto, CreateArticleCommentDto, CreateArticleCommentDto>
    {
    }
}
