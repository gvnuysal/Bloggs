using Abp.Application.Services.Dto;
using Bloggs.Users.Dto;

namespace Bloggs.Authors.Dto
{
    public class AuthorDto : FullAuditedEntityDto<long>
    {
        public long UserId { get; set; }
        public virtual UserDto User { get; set; }
        public bool IsActive { get; set; }
       
    }
}
