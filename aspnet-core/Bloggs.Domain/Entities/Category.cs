using Abp.Domain.Entities.Auditing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Domain.Entities
{
    public class Category:FullAuditedEntity<long>
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Article>  Articles { get; set; }
    }
}
