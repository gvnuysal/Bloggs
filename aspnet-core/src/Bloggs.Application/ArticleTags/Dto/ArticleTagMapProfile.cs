using AutoMapper;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleTags.Dto
{
    public class ArticleTagMapProfile : Profile
    {
        public ArticleTagMapProfile()
        {
            CreateMap<ArticleTag, CreateArticleTagDto>();
            CreateMap<CreateArticleTagDto, ArticleTag>();

            CreateMap<CreateArticleTagDto, ArticleTagDto>();
            CreateMap<ArticleTagDto, CreateArticleTagDto>();

            CreateMap<ArticleTagDto, ArticleTag>();
            CreateMap<ArticleTag, ArticleTagDto>();
        }
    }
}
