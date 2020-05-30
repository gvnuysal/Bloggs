using Abp.Application.Services.Dto;

namespace Bloggs.Categories.Dto
{

    public class CategoryDto:FullAuditedEntityDto<long>
    {
     
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
