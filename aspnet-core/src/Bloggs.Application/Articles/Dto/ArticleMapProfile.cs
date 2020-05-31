using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.Articles.Dto
{
    public class ArticleMapProfile : Profile
    {
        public ArticleMapProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();

            CreateMap<ArticleDto, CreateArticleDto>();
            CreateMap<CreateArticleDto, ArticleDto>();
        }
    }
}
