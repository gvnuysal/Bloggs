using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleComments.Dto
{
    public class PagedArticleCommentResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool IsAccept { get; set; }
    }
}
