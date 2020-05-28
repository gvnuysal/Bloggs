using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleComments.Dto
{
    public class PagedArticleFollowResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
    }
}
