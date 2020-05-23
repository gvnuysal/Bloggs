using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Bloggs.Domain.Entities
{
    public class Article:FullAuditedEntity<long>
    {
        [Required]
        public string Title { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string Contents { get; set; }
        [Required]
        public long AuthorId { get; set; }
        public Author Author { get; set; }
        [Required]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ArticleImage> ArticleImages { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
        public ICollection<ArticleComment> ArticleComments { get; set; }

    }
}
