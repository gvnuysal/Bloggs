using Abp.Application.Services.Dto;

namespace Bloggs.Authors.Dto
{
    public class PagedAuthorResultRequestDto : PagedResultRequestDto
    {
       
        public long UserId { get; set; }
    }
}
