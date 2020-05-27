using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Articles.Dto
{
    public class ArticleListDto : EntityDto
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public bool IsActive { get; set; }
        public long AuthorId { get; set; }
        public long CategoryId { get; set; }
    }
}
