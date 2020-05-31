using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.ArticleTags.Dto
{
    public class ArticleTagMapProfile : Profile
    {
        public ArticleTagMapProfile()
        {
            CreateMap<CreateArticleTagDto, ArticleTagDto>();
            CreateMap<ArticleTagDto, CreateArticleTagDto>();

            CreateMap<ArticleTagDto, ArticleTag>();
            CreateMap<ArticleTag, ArticleTagDto>();
        }
    }
}
