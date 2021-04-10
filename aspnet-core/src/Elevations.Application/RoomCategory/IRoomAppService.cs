namespace Elevations.RoomCategory
{
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    public interface
        IRoomAppService : IAsyncCrudAppService<RoomDto, int, PagedRoleResultRequestDto, UpdateRoomDto, RoomDto>
    {
        Task<ListResultDto<RoomDto>> GetAllRooms();
    }
}