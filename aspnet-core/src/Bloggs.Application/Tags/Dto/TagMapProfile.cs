using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.Tags.Dto
{
    public class TagMapProfile : Profile
    {
        public TagMapProfile()
        {
            CreateMap<TagDto, Tag>();
            CreateMap<Tag, TagDto>();

            CreateMap<TagDto, TagCreateDto>();
            CreateMap<TagCreateDto, TagDto>();
        }
    }
}
