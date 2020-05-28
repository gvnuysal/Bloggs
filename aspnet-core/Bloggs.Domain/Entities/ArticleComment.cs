using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class ArticleComment:FullAuditedEntity<long>
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public long ArticleId { get; set; }
        public Article Article { get; set; }
        public bool IsAccept { get; set; }
    }
}
