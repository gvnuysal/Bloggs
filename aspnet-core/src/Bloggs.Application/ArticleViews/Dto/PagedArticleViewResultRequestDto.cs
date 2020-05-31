using Abp.Application.Services.Dto;

namespace Bloggs.ArticleViews.Dto
{
    public class PagedArticleViewResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
