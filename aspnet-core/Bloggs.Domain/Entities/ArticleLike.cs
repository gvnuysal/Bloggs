using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    /// <summary>
    /// Burası makalenin beğeni ve görüntülenme sayısını tutacak
    /// </summary>
    public class ArticleLike : FullAuditedEntity<long>
    {
        [Required]
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
