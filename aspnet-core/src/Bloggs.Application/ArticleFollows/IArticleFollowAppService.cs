using Abp.Application.Services;
using Bloggs.ArticleFollows.Dto;

namespace Bloggs.ArticleFollows
{
    public interface IArticleFollowAppService : IAsyncCrudAppService<ArticleFollowDto, long, PagedArticleFollowResultRequestDto, CreateArticleFollowDto>
    {
    }
}
