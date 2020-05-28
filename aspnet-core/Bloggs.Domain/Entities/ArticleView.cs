using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class ArticleView : FullAuditedEntity<long>
    {
        [Required]
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
