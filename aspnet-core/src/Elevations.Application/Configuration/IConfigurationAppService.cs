namespace Elevations.Configuration
{
    using System.Threading.Tasks;

    using Elevations.Configuration.Dto;

    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}