using AutoMapper;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleLikes.Dto
{
    public class ArticleLikeMapProfile : Profile
    {
        public ArticleLikeMapProfile()
        {
            CreateMap<ArticleLikeDto, ArticleLike>();
            CreateMap<ArticleLike, ArticleLikeDto>();

            CreateMap<ArticleLike, CreateArticleLikeDto>();
            CreateMap<CreateArticleLikeDto, ArticleLike>();

            CreateMap<ArticleLikeDto, CreateArticleLikeDto>();
            CreateMap<CreateArticleLikeDto, ArticleLikeDto>();
        }
    }
}
