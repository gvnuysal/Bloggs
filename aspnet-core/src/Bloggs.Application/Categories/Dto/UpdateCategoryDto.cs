using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Categories.Dto
{
    [AutoMap(typeof(Category))]
    public class UpdateCategoryDto:EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
