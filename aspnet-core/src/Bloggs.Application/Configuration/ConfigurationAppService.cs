using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Bloggs.Configuration.Dto;

namespace Bloggs.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BloggsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
