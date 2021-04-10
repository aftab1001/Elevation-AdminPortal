namespace Elevations.Configuration
{
    using System.Threading.Tasks;

    using Abp.Authorization;
    using Abp.Runtime.Session;

    using Elevations.Configuration.Dto;

    [AbpAuthorize]
    public class ConfigurationAppService : ElevationsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                AbpSession.ToUserIdentifier(),
                AppSettingNames.UiTheme,
                input.Theme);
        }
    }
}