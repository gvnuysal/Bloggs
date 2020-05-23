using Abp.Domain.Entities.Auditing;
using Bloggs.Authorization.Users;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Domain.Entities
{
    public class Author:FullAuditedEntity<long>
    {
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<AuthorImage> AuthorImages { get; set; }
        public ICollection<AuthorFollow> AuthorFollows { get; set; }
    }
}
