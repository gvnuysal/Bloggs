using Abp.Application.Services.Dto;
using Bloggs.Authors.Dto;
using Bloggs.Categories.Dto;

namespace Bloggs.Articles.Dto
{
    public class ArticleDto : EntityDto<long>
    {
      
        public string Title { get; set; }

       
        public string Contents { get; set; }
        public bool IsActive { get; set; }
        public long AuthorId { get; set; }

     
        public long CategoryId { get; set; }

        public AuthorDto Author { get; set; }
        public CategoryDto Category { get; set; }
    }
}
