namespace Elevations.RoomCategory
{
    using Abp.Application.Services;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.Authorization;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;
   
    [AbpAuthorize(PermissionNames.Pages_Restaurant)]
    public class RestaurantAppService : AsyncCrudAppService<Dishes, DishesDto, int, PagedRoleResultRequestDto,
        DishesDto, DishesDto>

    {
        public RestaurantAppService(IRepository<Dishes, int> repository)
            : base(repository)
        {
        }
    }
}