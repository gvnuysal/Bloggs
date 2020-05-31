using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class ArticleComment : FullAuditedEntity<long>
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public long ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public bool IsAccept { get; set; }
    }
}
