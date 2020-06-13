using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Bloggs.Domain.Entities;
using Bloggs.Tags.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.Tags
{
    public class TagAppService : AsyncCrudAppService<Tag, TagDto, long, PagedTagResultRequestDto, CreateTagDto, UpdateTagDto>, ITagAppService
    {
        private IRepository<Tag, long> _repository;
        public TagAppService(IRepository<Tag, long> repository) : base(repository)
        {
            _repository = repository;
        }
        public override Task<PagedResultDto<TagDto>> GetAllAsync(PagedTagResultRequestDto input)
        {
            var articleFollows = _repository.GetAll()
                                     .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.ToLower().Contains(input.Keyword.Trim().ToLower()))
                                     .WhereIf(!input.IsDeleted.HasValue, x => x.IsDeleted == false)
                                     .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted)
                                     .Skip(input.SkipCount).Take(input.MaxResultCount)
                                     .ToList();

            var value = ObjectMapper.Map<List<TagDto>>(articleFollows);

            return Task.FromResult(new PagedResultDto<TagDto> { Items = value, TotalCount = value.Count() });
        }
        public async Task<GetTagUpdateOutput> GetTagForUpdate(EntityDto input)
        {
            var tag = await Repository.GetAsync(input.Id);
            var updateTagDto = ObjectMapper.Map<UpdateTagDto>(tag);

            return new GetTagUpdateOutput { Tag = updateTagDto };
        }
    }
}
