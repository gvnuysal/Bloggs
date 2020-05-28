using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.ArticleLikes.Dto
{
    public class CreateArticleLikeDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }
    }
}
