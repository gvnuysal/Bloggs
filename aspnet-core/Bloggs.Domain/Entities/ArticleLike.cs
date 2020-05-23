using Abp.Domain.Entities.Auditing;

namespace Bloggs.Domain.Entities
{
    /// <summary>
    /// Burası makalenin beğeni ve görüntülenme sayısını tutacak
    /// </summary>
    public class ArticleLike:FullAuditedEntity<long>
    {
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
