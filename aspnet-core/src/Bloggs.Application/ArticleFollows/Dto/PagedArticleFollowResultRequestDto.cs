using Abp.Application.Services.Dto;

namespace Bloggs.ArticleFollows.Dto
{
    public class PagedArticleFollowResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
