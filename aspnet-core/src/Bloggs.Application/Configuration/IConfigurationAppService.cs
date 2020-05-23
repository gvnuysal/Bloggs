using System.Threading.Tasks;
using Bloggs.Configuration.Dto;

namespace Bloggs.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
