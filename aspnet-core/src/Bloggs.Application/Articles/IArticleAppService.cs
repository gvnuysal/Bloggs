using Abp.Application.Services;
using Bloggs.Articles.Dto;

namespace Bloggs.Articles
{
    public interface IArticleAppService : IAsyncCrudAppService<ArticleDto, long, PagedArticleResultRequestDto, CreateArticleDto, UpdateArticleDto>
    {
    }
}
