using Abp.Application.Services.Dto;

namespace Bloggs.Tags.Dto
{
    public class PagedTagResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
