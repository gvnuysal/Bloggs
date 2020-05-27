using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.Authors.Dto
{
    public class AuthorMapProfile:Profile
    {
        public AuthorMapProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<Author, CreateAuthorDto>();
            CreateMap<CreateAuthorDto, Author>();

            CreateMap<AuthorDto, CreateAuthorDto>();
            CreateMap<CreateAuthorDto, AuthorDto>();
        }
    }
}
