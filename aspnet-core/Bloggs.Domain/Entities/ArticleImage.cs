using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class ArticleImage:FullAuditedEntity<long>
    {
        public long ImageId { get; set; }
        public Image Image { get; set; }
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
