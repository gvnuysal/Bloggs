using Abp.Application.Services.Dto;

namespace Bloggs.Tags.Dto
{
    public class TagListDto: PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
