using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using Bloggs.Authors.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.Authors
{
    public class AuthorAppService : AsyncCrudAppService<Author, AuthorDto, long, PagedAuthorResultRequestDto, CreateAuthorDto, UpdateAuthorDto>, IAuthorAppService
    {
        private readonly IRepository<Author, long> _repository;
        public AuthorAppService(IRepository<Author, long> repository) : base(repository)
        {
            _repository = repository;
            LocalizationSourceName = BloggsConsts.LocalizationSourceName;
        }

        public override async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            long? userId = AbpSession.UserId;

            var isAllReadyAuthor = GetAuthorDtoByUserId(userId);

            if(isAllReadyAuthor != null)
            {
                throw new UserFriendlyException(L("AllReadyAuthor"));
            }

            var author = new Author
            {
                UserId = Convert.ToInt64(userId),
                IsActive = input.IsActive
            };
            var authorDto = ObjectMapper.Map<AuthorDto>(author);

            var returnAutorDto = await base.CreateAsync(ObjectMapper.Map<CreateAuthorDto>(authorDto));


            return returnAutorDto;
        }

        public Author GetAuthorDtoByUserId(long? userId)
        {
            var getAllAuthorByUserId = _repository.GetAll().Where(x => x.UserId == userId).FirstOrDefault(); ;

            return getAllAuthorByUserId;
        }
        public override Task<PagedResultDto<AuthorDto>> GetAllAsync(PagedAuthorResultRequestDto input)
        {
            var authors = _repository.GetAll()
                                     .Include(x => x.User)
                                     .WhereIf(!input.FullName.IsNullOrWhiteSpace(), x => x.User.FullName.ToLower().Contains(input.FullName.Trim().ToLower()))
                                     .WhereIf(input.UserId > 0, x => x.UserId.ToString() == input.UserId.ToString().Trim())
                                     .WhereIf(input.IsDeleted.HasValue, x => x.IsDeleted == input.IsDeleted)
                                     .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive)
                                     .ToList();

            var value = ObjectMapper.Map<List<AuthorDto>>(authors);

            return Task.FromResult(new PagedResultDto<AuthorDto> { Items = value, TotalCount = value.Count() });
        }

        public async Task<GetAuthorUpdateOutput> GetAuthorForUpdate(EntityDto input)
        {
            var author = await Repository.GetAsync(input.Id);
            var updateAuthorDto = ObjectMapper.Map<UpdateAuthorDto>(author);

            return new GetAuthorUpdateOutput { Author = updateAuthorDto };
        }
    }
}
