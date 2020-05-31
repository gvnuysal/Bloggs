using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleTags.Dto
{
    [AutoMap(typeof(ArticleTag))]
    public class UpdateArticleTagDto : EntityDto<long>
    {
        [Required]
        public long TagId { get; set; }
    }
}
