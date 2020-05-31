using Abp.Application.Services;
using Bloggs.ArticleTags.Dto;

namespace Bloggs.ArticleTags
{
    public interface IArticleTagAppService : IAsyncCrudAppService<ArticleTagDto, long, PagedArticleTagResultRequestDto, CreateArticleTagDto, UpdateArticleTagDto>
    {
    }
}
