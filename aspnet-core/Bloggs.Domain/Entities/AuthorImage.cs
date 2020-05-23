using Abp.Domain.Entities.Auditing;

namespace Bloggs.Domain.Entities
{
    public class AuthorImage:FullAuditedEntity<long>
    {
        public bool IsActive { get; set; }
        public long ImageId { get; set; }
        public Image Image { get; set; }
        public long AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
