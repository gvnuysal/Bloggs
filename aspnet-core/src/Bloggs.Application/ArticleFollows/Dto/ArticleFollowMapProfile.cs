using AutoMapper;
using Bloggs.ArticleComments.Dto;
using Bloggs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggs.ArticleFollows.Dto
{
    public class ArticleFollowMapProfile : Profile
    {
        public ArticleFollowMapProfile()
        {
            CreateMap<ArticleFollowDto, ArticleFollow>();
            CreateMap<ArticleFollow, ArticleFollowDto>();

            CreateMap<CreateArticleFollowDto, ArticleFollow>();
            CreateMap<ArticleFollow, CreateArticleFollowDto>();

            CreateMap<CreateArticleFollowDto, ArticleFollowDto>();
            CreateMap<ArticleFollowDto, CreateArticleFollowDto>();
        }
    }
}
