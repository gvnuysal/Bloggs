using Abp.Application.Services.Dto;
using Bloggs.Authors.Dto;
using Bloggs.Categories.Dto;
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
        public AuthorDto Author { get; set; }
        public CategoryDto Category { get; set; }

    }
}
