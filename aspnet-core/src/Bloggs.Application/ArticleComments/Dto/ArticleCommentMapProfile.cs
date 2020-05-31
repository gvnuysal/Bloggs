using Abp.Application.Services.Dto;
using AutoMapper;
using Bloggs.Domain.Entities;

namespace Bloggs.ArticleComments.Dto
{
    public class ArticleCommentMapProfile : Profile
    {
        public ArticleCommentMapProfile()
        {
            CreateMap<ArticleCommentDto, ArticleComment>();
            CreateMap<ArticleComment, ArticleCommentDto>();

            CreateMap<CreateArticleCommentDto, ArticleCommentDto>();
            CreateMap<ArticleCommentDto, CreateArticleCommentDto>();
        }
    }
}
