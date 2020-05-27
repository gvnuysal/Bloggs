using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Bloggs.Authors.Dto;
using Bloggs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bloggs.Authors
{
    public interface IAuthorAppService:IAsyncCrudAppService<AuthorDto,long,PagedAuthorResultRequestDto,CreateAuthorDto,CreateAuthorDto>
    {
        Author GetAuthorDtoByUserId(long? userId);
      
    }
}
