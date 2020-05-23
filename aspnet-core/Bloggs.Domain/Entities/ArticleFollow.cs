using Abp.Domain.Entities.Auditing;

namespace Bloggs.Domain.Entities
{
    public class ArticleFollow:FullAuditedEntity<long>
    {
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
