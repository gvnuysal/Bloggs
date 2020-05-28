using AutoMapper;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleComments.Dto
{
    public class ArticleCommentMapProfile : Profile
    {
        public ArticleCommentMapProfile()
        {
            CreateMap<ArticleCommentDto, ArticleComment>();
            CreateMap<ArticleComment, ArticleCommentDto>();

            CreateMap<CreateArticleCommentDto, ArticleComment>();
            CreateMap<ArticleComment, CreateArticleCommentDto>();

            CreateMap<CreateArticleCommentDto, ArticleCommentDto>();
            CreateMap<ArticleCommentDto, CreateArticleCommentDto>();
        }
    }
}
