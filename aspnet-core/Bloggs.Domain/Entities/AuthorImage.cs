using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class AuthorImage : FullAuditedEntity<long>
    {
        public bool IsActive { get; set; }

        [Required]
        public long ImageId { get; set; }
        public Image Image { get; set; }

        [Required]
        public long AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
