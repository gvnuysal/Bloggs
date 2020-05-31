using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.ArticleLikes.Dto
{
    public class ArticleLikeMapProfile : Profile
    {
        public ArticleLikeMapProfile()
        {
            CreateMap<ArticleLikeDto, ArticleLike>();
            CreateMap<ArticleLike, ArticleLikeDto>();

            CreateMap<ArticleLikeDto, CreateArticleLikeDto>();
            CreateMap<CreateArticleLikeDto, ArticleLikeDto>();
        }
    }
}
