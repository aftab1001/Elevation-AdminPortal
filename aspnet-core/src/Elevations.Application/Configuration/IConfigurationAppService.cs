using System.Threading.Tasks;
using Elevations.Configuration.Dto;

namespace Elevations.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
