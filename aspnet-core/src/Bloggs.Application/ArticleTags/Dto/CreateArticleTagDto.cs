﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleTags.Dto
{
    [AutoMap(typeof(ArticleTag))]
    public class CreateArticleTagDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }

        [Required]
        public long TagId { get; set; }
    }
}
