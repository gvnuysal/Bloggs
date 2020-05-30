using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class Category : FullAuditedEntity<long>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
