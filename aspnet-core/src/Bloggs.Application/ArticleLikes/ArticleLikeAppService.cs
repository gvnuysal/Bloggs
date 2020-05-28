using Abp.Application.Services;
using Abp.Domain.Repositories;
using Bloggs.ArticleLikes.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleLikes
{
    public class ArticleLikeAppService : AsyncCrudAppService<ArticleLike, ArticleLikeDto, long, PagedArticleLikeResultRequestDto, CreateArticleLikeDto, CreateArticleLikeDto>, IArticleLikeAppService
    {
        public ArticleLikeAppService(IRepository<ArticleLike, long> repository) : base(repository)
        {
        }
    }
}
