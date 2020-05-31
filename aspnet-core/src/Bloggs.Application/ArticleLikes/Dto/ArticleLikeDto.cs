using Abp.Application.Services.Dto;
using Bloggs.Articles.Dto;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleLikes.Dto
{
    public class ArticleLikeDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }

        public ArticleDto Article { get; set; }
    }
}
