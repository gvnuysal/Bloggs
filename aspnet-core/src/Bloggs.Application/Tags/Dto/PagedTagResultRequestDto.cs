using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Tags.Dto
{
    public class PagedTagResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
