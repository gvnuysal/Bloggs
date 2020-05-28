using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class ArticleImage : FullAuditedEntity<long>
    {
        [Required]
        public long ImageId { get; set; }
        public Image Image { get; set; }

        [Required]
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
