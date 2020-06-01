using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Bloggs.Tags.Dto;
using System.Threading.Tasks;

namespace Bloggs.Tags
{
    public interface ITagAppService : IAsyncCrudAppService<TagDto, long, PagedTagResultRequestDto, CreateTagDto, UpdateTagDto>
    {
        Task<GetTagUpdateOutput> GetTagForUpdate(EntityDto input);
    }
}
