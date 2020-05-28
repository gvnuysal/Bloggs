using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class ArticleFollow:FullAuditedEntity<long>
    {
        [Required]
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
