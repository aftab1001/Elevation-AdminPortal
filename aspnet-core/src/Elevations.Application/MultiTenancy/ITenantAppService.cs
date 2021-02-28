using Abp.Application.Services;
using Elevations.MultiTenancy.Dto;

namespace Elevations.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

