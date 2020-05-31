using Abp.Application.Services.Dto;
using Bloggs.Articles.Dto;
using Bloggs.Tags.Dto;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleTags.Dto
{
    public class ArticleTagDto : EntityDto<long>
    {
        [Required]
        public long ArticleId { get; set; }

        [Required]
        public long TagId { get; set; }

        public ArticleDto Article { get; set; }
        public TagDto Tag { get; set; }
    }
}
