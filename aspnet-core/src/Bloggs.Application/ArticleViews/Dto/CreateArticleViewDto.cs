using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleViews.Dto
{
    [AutoMap(typeof(ArticleView))]
    public class CreateArticleViewDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }
    }
}
