using Abp.Domain.Entities.Auditing;

namespace Bloggs.Domain.Entities
{
    public class AuthorFollow:FullAuditedEntity<long>
    {
        public long AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
