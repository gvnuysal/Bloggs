using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class Image : FullAuditedEntity<long>
    {
        [Required]
        public byte[] FileName { get; set; }

    }
}
