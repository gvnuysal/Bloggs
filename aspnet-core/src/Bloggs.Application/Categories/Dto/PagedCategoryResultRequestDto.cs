﻿using Abp.Application.Services.Dto;

namespace Bloggs.Categories.Dto
{
    public class PagedCategoryResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
