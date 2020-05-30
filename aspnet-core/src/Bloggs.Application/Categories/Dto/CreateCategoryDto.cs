using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Categories.Dto
{
    public class CreateCategoryDto:EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
