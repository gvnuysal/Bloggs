using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.ArticleComments.Dto
{
    public class CreateArticleCommentDto : EntityDto<long>
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public long ArticleId { get; set; }

        public bool IsAccept { get; set; }
    }
}
