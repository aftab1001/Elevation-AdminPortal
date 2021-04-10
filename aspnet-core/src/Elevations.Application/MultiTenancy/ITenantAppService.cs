namespace Elevations.MultiTenancy
{
    using Abp.Application.Services;

    using Elevations.MultiTenancy.Dto;

    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto,
        CreateTenantDto, TenantDto>
    {
    }
}