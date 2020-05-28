using Abp.Application.Services;
using Abp.Domain.Repositories;
using Bloggs.ArticleComments.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bloggs.ArticleComments
{
    public class ArticleCommentAppService : AsyncCrudAppService<ArticleComment, ArticleCommentDto, long, PagedArticleCommentResultRequestDto, CreateArticleCommentDto, CreateArticleCommentDto>, IArticleCommentAppService
    {
        public ArticleCommentAppService(IRepository<ArticleComment, long> repository) : base(repository)
        {

        }
    }
}
