namespace Elevations.Sessions
{
    using System.Threading.Tasks;

    using Abp.Application.Services;

    using Elevations.Sessions.Dto;

    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}