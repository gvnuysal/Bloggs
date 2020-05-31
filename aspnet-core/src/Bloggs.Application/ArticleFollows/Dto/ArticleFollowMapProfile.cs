using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.ArticleFollows.Dto
{
    public class ArticleFollowMapProfile : Profile
    {
        public ArticleFollowMapProfile()
        {
            CreateMap<ArticleFollowDto, ArticleFollow>();
            CreateMap<ArticleFollow, ArticleFollowDto>();

            CreateMap<CreateArticleFollowDto, ArticleFollowDto>();
            CreateMap<ArticleFollowDto, CreateArticleFollowDto>();
        }
    }
}
