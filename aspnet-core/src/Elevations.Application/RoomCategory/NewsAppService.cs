namespace Elevations.RoomCategory
{
    using Abp.Application.Services;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.Authorization;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    [AbpAuthorize(PermissionNames.Pages_News)]
    public class NewsAppService : AsyncCrudAppService<News, NewsDto, int, PagedRoleResultRequestDto
        , UpdateNewsDto, NewsDto>

    {
        public NewsAppService(IRepository<News, int> repository)
            : base(repository)
        {
        }
    }
}