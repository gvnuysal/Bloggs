using Abp.Application.Services.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.ArticleViews.Dto
{
    public class ArticleViewDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
