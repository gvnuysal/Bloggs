using AutoMapper;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.Articles.Dto
{
    public class ArticleMapProfile : Profile
    {
        public ArticleMapProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();

            CreateMap<Article, CreateArticleDto>();
            CreateMap<CreateArticleDto, Article>();

            CreateMap<ArticleDto, CreateArticleDto>();
            CreateMap<CreateArticleDto, ArticleDto>();
        }
    }
}
