using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Categories.Dto
{
    [AutoMapTo(typeof(Category))]
    public class CategoryDto:EntityDto<long>
    {
        [Required]
        public string Name { get; set; }
    }
}
