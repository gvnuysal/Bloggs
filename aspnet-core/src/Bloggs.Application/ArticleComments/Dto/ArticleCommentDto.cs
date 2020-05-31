using Abp.Application.Services.Dto;
using Bloggs.Articles.Dto;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleComments.Dto
{
    public class ArticleCommentDto : EntityDto<long>
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public long ArticleId { get; set; }

        public ArticleDto Article { get; set; }

        public bool IsAccept { get; set; }
    }
}
