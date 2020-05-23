using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class ArticleTag:FullAuditedEntity<long>
    {
        public long TagId { get; set; }
        public Tag Tag { get; set; }
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
