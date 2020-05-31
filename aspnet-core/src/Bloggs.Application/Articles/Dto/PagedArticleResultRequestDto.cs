using Abp.Application.Services.Dto;

namespace Bloggs.Articles.Dto
{
    public class PagedArticleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public long AuthorId { get; set; }
        public long CategoryId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
