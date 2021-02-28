using System.Threading.Tasks;
using Abp.Application.Services;
using Elevations.Sessions.Dto;

namespace Elevations.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
