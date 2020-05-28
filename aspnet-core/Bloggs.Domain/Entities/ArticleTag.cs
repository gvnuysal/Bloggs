using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class ArticleTag : FullAuditedEntity<long>
    {
        [Required]
        public long TagId { get; set; }
        public Tag Tag { get; set; }

        [Required]
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
