using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class ArticleComment:FullAuditedEntity<long>
    {
        public string Comment { get; set; }
        public long ArticleId { get; set; }
        public Article Article { get; set; }
        public bool IsAccept { get; set; }
    }
}
