using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Bloggs.Authorization.Users;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class Author : FullAuditedEntity<long>
    {
        [Required]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public bool IsActive { get; set; }
    }
}
