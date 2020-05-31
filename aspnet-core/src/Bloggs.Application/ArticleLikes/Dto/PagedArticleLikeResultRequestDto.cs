using Abp.Application.Services.Dto;

namespace Bloggs.ArticleLikes.Dto
{
    public class PagedArticleLikeResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
