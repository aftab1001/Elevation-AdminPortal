namespace Elevations.RoomCategory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.Authorization;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    [AbpAuthorize(PermissionNames.Pages_Rooms)]
    public class RoomAppService :
        AsyncCrudAppService<Rooms, RoomDto, int, PagedRoleResultRequestDto, UpdateRoomDto, RoomDto>,
        IRoomAppService
    {
        private readonly IRepository<Rooms> roomsRepository;

        public RoomAppService(IRepository<Rooms> roomsRepository)
            : base(roomsRepository)
        {
            this.roomsRepository = roomsRepository;
        }
     
        [AbpAllowAnonymous]
        public Task<ListResultDto<RoomDto>> GetAllRooms()
        {
            IQueryable<Rooms> roomsList = roomsRepository.GetAll();

            return Task.FromResult(
                new ListResultDto<RoomDto>(ObjectMapper.Map<List<RoomDto>>(roomsList).OrderBy(p => p.Name).ToList()));
        }

        public Task<RoomDto> UpdateRooms(EntityDto input)
        {
            throw new NotImplementedException();
        }
    }
}