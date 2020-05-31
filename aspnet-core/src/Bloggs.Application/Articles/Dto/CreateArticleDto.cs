using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bloggs.Articles.Dto
{
    [AutoMap(typeof(Article))]
    public class CreateArticleDto : EntityDto<long>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public long AuthorId { get; set; }

        [Required]
        public long CategoryId { get; set; }
    }
}
