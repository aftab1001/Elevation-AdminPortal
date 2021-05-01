using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Elevations.Roles.Dto;
using Elevations.Services.Dto;

namespace Elevations.Services
{
    public interface
        IRoomAppService : IAsyncCrudAppService<RoomDto, int, PagedRoleResultRequestDto, UpdateRoomDto, RoomDto>
    {
        Task<ListResultDto<RoomDto>> GetAllRooms();
    }
}