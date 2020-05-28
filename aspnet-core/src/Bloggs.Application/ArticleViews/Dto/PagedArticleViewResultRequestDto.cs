using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleViews.Dto
{
    public class PagedArticleViewResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
    }
}
