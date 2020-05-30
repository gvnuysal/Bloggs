using Abp.Domain.Entities.Auditing;
using Bloggs.Authorization.Users;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class Author : FullAuditedEntity<long>
    {
        [Required]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public bool IsActive { get; set; }
    }
}
