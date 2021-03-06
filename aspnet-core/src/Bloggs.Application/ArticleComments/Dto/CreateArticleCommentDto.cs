﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleComments.Dto
{
    [AutoMap(typeof(ArticleComment))]
    public class CreateArticleCommentDto : EntityDto<long>
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public long ArticleId { get; set; }

        public bool IsAccept { get; set; }
    }
}
