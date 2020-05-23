using Abp.Domain.Entities.Auditing;
using Bloggs.Authorization.Users;

namespace Bloggs.Domain.Entities
{
    public class UserChat:FullAuditedEntity<long>
    {
        public string Message { get; set; }
        public bool IsViewed { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
