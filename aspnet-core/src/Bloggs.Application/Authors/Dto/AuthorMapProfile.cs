using Abp.Application.Services.Dto;
using AutoMapper;
using Bloggs.Domain.Entities;
using System.Threading.Tasks;

namespace Bloggs.Authors.Dto
{
    public class AuthorMapProfile : Profile
    {
        public AuthorMapProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<Author, CreateAuthorDto>();
            CreateMap<CreateAuthorDto, Author>();

            CreateMap<AuthorDto, CreateAuthorDto>();
            CreateMap<CreateAuthorDto, AuthorDto>();

            CreateMap<Author, PagedResultDto<AuthorDto>>();
            CreateMap<PagedResultDto<AuthorDto>, Author>();
        }
    }
}
