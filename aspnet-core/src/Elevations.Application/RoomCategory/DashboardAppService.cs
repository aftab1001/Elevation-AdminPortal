namespace Elevations.RoomCategory
{
    using Abp.Application.Services;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.Authorization;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    [AbpAuthorize(PermissionNames.Pages_Dashboard)]
    public class DashboardAppService : AsyncCrudAppService<Dashboard, DashboardDto, int, PagedRoleResultRequestDto,
        DashboardDto, DashboardDto>

    {
        public DashboardAppService(IRepository<Dashboard, int> repository)
            : base(repository)
        {
        }
    }
}