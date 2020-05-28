using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Articles.Dto
{
    public class PagedArticleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public long AuthorId { get; set; }
        public long CategoryId { get; set; }
    }
}
