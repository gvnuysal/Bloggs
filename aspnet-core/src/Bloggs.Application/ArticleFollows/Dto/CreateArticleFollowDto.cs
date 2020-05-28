using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.ArticleComments.Dto
{
    public class CreateArticleFollowDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }
    }
}
