using Abp.Application.Services;
using Bloggs.ArticleLikes.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleLikes
{
    public interface IArticleLikeAppService : IAsyncCrudAppService<ArticleLikeDto, long, PagedArticleLikeResultRequestDto, CreateArticleLikeDto, CreateArticleLikeDto>
    {
    }
}
