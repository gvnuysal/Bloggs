using Abp.Application.Services.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.ArticleTags.Dto
{
    public class ArticleTagDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }
        public Article Article { get; set; }

        [Required]
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
