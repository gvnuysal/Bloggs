using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Bloggs.Domain.Entities;
using Bloggs.Tags.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.Tags
{
    public class TagAppService : AsyncCrudAppService<Tag, TagCreateDto, long, PagedTagResultRequestDto, TagCreateDto, TagCreateDto>, ITagAppService
    {
        public TagAppService(IRepository<Tag, long> repository) : base(repository)
        {

        }
        protected override IQueryable<Tag> CreateFilteredQuery(PagedTagResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.ToLower().Contains(input.Keyword.Trim().ToLower()));
        }
    }
}
