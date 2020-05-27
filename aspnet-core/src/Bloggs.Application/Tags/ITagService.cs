using Abp.Application.Services;
using Bloggs.Tags.Dto;

namespace Bloggs.Tags
{
    public interface ITagService:IAsyncCrudAppService<TagCreateDto,long,TagListDto,TagCreateDto,TagCreateDto>
    {
       
    }
}
