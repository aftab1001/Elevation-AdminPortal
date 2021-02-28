using System.Threading.Tasks;
using Abp.Application.Services;
using Elevations.Authorization.Accounts.Dto;

namespace Elevations.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
