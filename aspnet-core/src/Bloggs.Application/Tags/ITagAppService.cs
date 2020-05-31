using Abp.Application.Services;
using Bloggs.Tags.Dto;

namespace Bloggs.Tags
{
    public interface ITagAppService : IAsyncCrudAppService<TagDto, long, PagedTagResultRequestDto, TagCreateDto, TagCreateDto>
    {

    }
}
