using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.Authors.Dto
{
    [AutoMap(typeof(Author))]
    public class UpdateAuthorDto : EntityDto<long>
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
