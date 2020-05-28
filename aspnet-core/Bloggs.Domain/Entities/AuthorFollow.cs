using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class AuthorFollow:FullAuditedEntity<long>
    {
        [Required]
        public long AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
