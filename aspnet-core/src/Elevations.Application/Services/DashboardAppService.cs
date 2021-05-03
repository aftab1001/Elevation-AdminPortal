﻿using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Elevations.EntityFrameworkCore.HotelDto;
using Elevations.Roles.Dto;
using Elevations.Services.Dto;

namespace Elevations.Services
{
    //[AbpAuthorize(PermissionNames.Pages_Dashboard)]
    [AbpAllowAnonymous]
    public class DashboardAppService : AsyncCrudAppService<Dashboard, DashboardDto, int, PagedRoleResultRequestDto,
        DashboardDto, DashboardDto>

    {
        public DashboardAppService(IRepository<Dashboard, int> repository)
            : base(repository)
        {
        }
    }
}