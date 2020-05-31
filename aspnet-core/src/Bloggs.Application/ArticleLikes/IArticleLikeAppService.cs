using Abp.Application.Services;
using Bloggs.ArticleLikes.Dto;

namespace Bloggs.ArticleLikes
{
    public interface IArticleLikeAppService : IAsyncCrudAppService<ArticleLikeDto, long, PagedArticleLikeResultRequestDto, CreateArticleLikeDto, CreateArticleLikeDto>
    {
    }
}
