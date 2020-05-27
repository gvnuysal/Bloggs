using Abp.Application.Services.Dto;
using Bloggs.Authorization.Users;
using Bloggs.Domain.Entities;
using System.Collections.Generic;

namespace Bloggs.Authors.Dto
{
    public class AuthorDto : FullAuditedEntityDto<long>
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
