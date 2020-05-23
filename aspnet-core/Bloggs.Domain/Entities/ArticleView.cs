using Abp.Domain.Entities.Auditing;

namespace Bloggs.Domain.Entities
{
    public class ArticleView:FullAuditedEntity<long>
    {
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
