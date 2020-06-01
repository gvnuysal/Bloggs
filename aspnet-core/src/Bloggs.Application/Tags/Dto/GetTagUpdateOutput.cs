using Abp.Application.Services.Dto;

namespace Bloggs.Tags.Dto
{
    public  class GetTagUpdateOutput : EntityDto<long>
    {
        public UpdateTagDto Tag { get; set; }
    }
}
