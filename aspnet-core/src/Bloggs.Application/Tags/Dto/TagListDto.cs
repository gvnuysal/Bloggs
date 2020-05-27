using Abp.Application.Services.Dto;

namespace Bloggs.Tags.Dto
{
    public class TagListDto : EntityDto<long>
    {
        public string Name { get; set; }
    }
}
