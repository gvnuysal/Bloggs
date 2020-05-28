using Abp.Domain.Entities.Auditing;
using Bloggs.Authorization.Users;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class UserChat : FullAuditedEntity<long>
    {
        [Required]
        public string Message { get; set; }

        public bool IsViewed { get; set; }

        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
