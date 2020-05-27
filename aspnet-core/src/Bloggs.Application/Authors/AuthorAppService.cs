using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Bloggs.Authors.Dto;
using Bloggs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggs.Authors
{
    public class AuthorAppService : AsyncCrudAppService<Author, AuthorDto, long, PagedAuthorResultRequestDto, CreateAuthorDto, CreateAuthorDto>, IAuthorAppService
    {
        private readonly IRepository<Author, long> _repository;
        public AuthorAppService(IRepository<Author, long> repository) : base(repository)
        {
            _repository = repository;
            LocalizationSourceName = BloggsConsts.LocalizationSourceName;
        }
        public override Task<PagedResultDto<AuthorDto>> GetAllAsync(PagedAuthorResultRequestDto input)
        {
           
            return base.GetAllAsync(input);
        }
        public override async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            long? userId = AbpSession.UserId;

            var isAllReadyAuthor = GetAuthorDtoByUserId(userId);

            if (isAllReadyAuthor != null)
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

       
    }
}
