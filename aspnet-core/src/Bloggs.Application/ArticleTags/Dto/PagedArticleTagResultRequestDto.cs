using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleTags.Dto
{
    public class PagedArticleTagResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
        public long TagId { get; set; }
    }
}
