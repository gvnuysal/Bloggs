using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Bloggs.Articles.Dto;
using System.Threading.Tasks;

namespace Bloggs.Articles
{
    public interface IArticleAppService : IAsyncCrudAppService<ArticleDto, long, PagedArticleResultRequestDto, CreateArticleDto, UpdateArticleDto>
    {
        Task<GetArticleUpdateOutput> GetArticleForUpdate(EntityDto input);
    }
}
