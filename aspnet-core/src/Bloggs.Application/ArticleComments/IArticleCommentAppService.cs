using Abp.Application.Services;
using Bloggs.ArticleComments.Dto;

namespace Bloggs.ArticleComments
{
    public interface IArticleCommentAppService : IAsyncCrudAppService<ArticleCommentDto, long, PagedArticleCommentResultRequestDto, CreateArticleCommentDto, UpdateArticleCommentDto>
    {
    }
}
