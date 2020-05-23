using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class Image:FullAuditedEntity<long>
    {
        public byte[] FileName { get; set; }
        public ICollection<ArticleImage> ArticleImages { get; set; }
        public ICollection<AuthorImage> AuthorImages { get; set; }
    }
}
