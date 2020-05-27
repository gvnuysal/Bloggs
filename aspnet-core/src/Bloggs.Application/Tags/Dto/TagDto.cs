using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bloggs.Tags.Dto
{
    public class TagDto : EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
    }
}
