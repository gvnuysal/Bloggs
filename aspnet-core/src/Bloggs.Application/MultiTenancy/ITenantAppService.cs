using Abp.Application.Services;
using Bloggs.MultiTenancy.Dto;

namespace Bloggs.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

