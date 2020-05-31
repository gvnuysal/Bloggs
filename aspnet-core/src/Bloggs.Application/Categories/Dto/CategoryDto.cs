using Abp.Application.Services.Dto;

namespace Bloggs.Categories.Dto
{

    public class CategoryDto:EntityDto<long>
    {
     
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
