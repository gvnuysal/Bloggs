using Abp.Application.Services.Dto;

namespace Bloggs.ArticleComments.Dto
{
    public class PagedArticleCommentResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
        public string Keyword { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAccept { get; set; }
    }
}
