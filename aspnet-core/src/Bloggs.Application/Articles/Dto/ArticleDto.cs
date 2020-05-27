using Abp.Application.Services.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Articles.Dto
{
    public class ArticleDto : EntityDto<long>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public long AuthorId { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
