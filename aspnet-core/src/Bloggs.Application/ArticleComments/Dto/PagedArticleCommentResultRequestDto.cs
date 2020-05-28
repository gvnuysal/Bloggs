using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleComments.Dto
{
    public class PagedArticleCommentResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
        public string Keyword { get; set; }
    }
}
