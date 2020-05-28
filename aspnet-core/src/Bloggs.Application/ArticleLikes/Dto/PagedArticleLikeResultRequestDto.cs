using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleLikes.Dto
{
    public class PagedArticleLikeResultRequestDto : PagedResultRequestDto
    {
        public long ArticleId { get; set; }
    }
}
