using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Bloggs.MultiTenancy;

namespace Bloggs.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
