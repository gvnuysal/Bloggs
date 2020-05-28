using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
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
        protected override IQueryable<Article> CreateFilteredQuery(PagedArticleResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Contents.ToLower().Contains(input.Keyword.Trim().ToLower())
                || x.Title.ToLower().Contains(input.Keyword.Trim().ToLower()))
                .WhereIf(input.AuthorId > 0, x => x.AuthorId == input.AuthorId)
                .WhereIf(input.CategoryId > 0, x => x.CategoryId == input.CategoryId);
        }
    }
}
