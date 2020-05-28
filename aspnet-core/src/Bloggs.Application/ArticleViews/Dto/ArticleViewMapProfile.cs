using AutoMapper;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleViews.Dto
{
    public class ArticleViewMapProfile : Profile
    {
        public ArticleViewMapProfile()
        {
            CreateMap<ArticleView, CreateArticleViewDto>();
            CreateMap<CreateArticleViewDto, ArticleView>();

            CreateMap<CreateArticleViewDto, ArticleViewDto>();
            CreateMap<ArticleViewDto, CreateArticleViewDto>();

            CreateMap<ArticleViewDto, ArticleView>();
            CreateMap<ArticleView, ArticleViewDto>();
        }
    }
}
