using Abp.Application.Services.Dto;

namespace Bloggs.Authors.Dto
{
    public class CreateAuthorDto: EntityDto<long>
    {
        public long UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
