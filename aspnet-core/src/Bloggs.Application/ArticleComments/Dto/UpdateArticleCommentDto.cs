using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.ArticleComments.Dto
{
    [AutoMap(typeof(ArticleComment))]
    public class UpdateArticleCommentDto : EntityDto<long>
    {
        [Required]
        public string Comment { get; set; }
    }
}
