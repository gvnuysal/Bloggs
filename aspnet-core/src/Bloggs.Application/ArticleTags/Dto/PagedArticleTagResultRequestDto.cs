using Abp.Application.Services.Dto;

namespace Bloggs.ArticleTags.Dto
{
    public class PagedArticleTagResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
        public long TagId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
