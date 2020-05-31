using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Tags.Dto
{
    public class TagDto : EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
    }
}
