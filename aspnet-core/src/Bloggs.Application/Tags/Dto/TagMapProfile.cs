using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.Tags.Dto
{
    public class TagMapProfile:Profile
    {
        public TagMapProfile()
        {
            CreateMap<Tag, TagCreateDto>();
            CreateMap<TagCreateDto, Tag>();
            CreateMap<Tag, TagListDto>();
        }
    }
}
