using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleLikes.Dto
{
    [AutoMap(typeof(ArticleLike))]
    public class CreateArticleLikeDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }
    }
}
