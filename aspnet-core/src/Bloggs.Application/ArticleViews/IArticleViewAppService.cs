using Abp.Application.Services;
using Bloggs.ArticleViews.Dto;

namespace Bloggs.ArticleViews
{
    public interface IArticleViewAppService : IAsyncCrudAppService<ArticleViewDto, long, PagedArticleViewResultRequestDto, CreateArticleViewDto, CreateArticleViewDto>
    {
    }
}
