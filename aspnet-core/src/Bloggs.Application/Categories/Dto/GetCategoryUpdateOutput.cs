using Abp.Application.Services.Dto;

namespace Bloggs.Categories.Dto
{
    public class GetCategoryUpdateOutput:EntityDto<long>
    {
        public UpdateCategoryDto Category { get; set; }
    }
}
