using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.ArticleTags.Dto
{
    public class CreateArticleTagDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }

        [Required]
        public long TagId { get; set; }
    }
}
