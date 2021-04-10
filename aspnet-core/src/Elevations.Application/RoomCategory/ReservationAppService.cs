namespace Elevations.RoomCategory
{
    using Abp.Application.Services;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    //[AbpAuthorize(PermissionNames.Pages_Reservation)]
    [AbpAllowAnonymous]
    public class ReservationAppService : AsyncCrudAppService<Reservation, ReservationDto, int, PagedRoleResultRequestDto
        , UpdateReservationDto, ReservationDto>

    {
        public ReservationAppService(IRepository<Reservation, int> repository)
            : base(repository)
        {
        }
    }
}