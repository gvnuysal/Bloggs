using System.Threading.Tasks;
using Abp.Application.Services;
using Bloggs.Sessions.Dto;

namespace Bloggs.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
