using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Bloggs.Domain.Entities;
using Bloggs.Tags.Dto;
using System.Threading.Tasks;

namespace Bloggs.Tags
{
    public class TagAppService :AsyncCrudAppService<Tag,TagCreateDto,long,TagListDto,TagCreateDto,TagCreateDto>,ITagService
    {
        public TagAppService(IRepository<Tag,long> repository):base(repository)
        {

        }

      
    }
}
