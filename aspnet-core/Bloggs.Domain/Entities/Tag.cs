using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class Tag : FullAuditedEntity<long>
    {
        [Required]
        public string Name { get; set; }
    }
}
