using Abp.Application.Services.Dto;

namespace Bloggs.Authors.Dto
{
    public class PagedAuthorResultRequestDto : PagedResultRequestDto
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
    }
}
