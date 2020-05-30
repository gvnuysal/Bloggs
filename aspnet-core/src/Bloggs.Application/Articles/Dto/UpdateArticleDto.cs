using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Articles.Dto
{
    [AutoMap(typeof(Article))]
    public class UpdateArticleDto:EntityDto<long>
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string Contents { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
