using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleFollows.Dto
{
    [AutoMap(typeof(ArticleFollow))]
    public class CreateArticleFollowDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }
    }
}
