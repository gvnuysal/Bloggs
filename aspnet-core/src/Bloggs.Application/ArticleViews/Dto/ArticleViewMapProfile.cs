using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.ArticleViews.Dto
{
    public class ArticleViewMapProfile : Profile
    {
        public ArticleViewMapProfile()
        {
            CreateMap<CreateArticleViewDto, ArticleViewDto>();
            CreateMap<ArticleViewDto, CreateArticleViewDto>();

            CreateMap<ArticleViewDto, ArticleView>();
            CreateMap<ArticleView, ArticleViewDto>();
        }
    }
}
