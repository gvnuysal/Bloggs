using System.Threading.Tasks;
using Abp.Application.Services;
using Bloggs.Authorization.Accounts.Dto;

namespace Bloggs.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
