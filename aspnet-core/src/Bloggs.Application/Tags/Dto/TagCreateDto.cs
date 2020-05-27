using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Tags.Dto
{
    public class TagCreateDto:EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
    }
}
