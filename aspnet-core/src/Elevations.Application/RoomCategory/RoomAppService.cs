namespace Elevations.RoomCategory
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    //  [AbpAuthorize(PermissionNames.Pages_Rooms)]
    [AbpAllowAnonymous]
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

        public override async Task<RoomDto> CreateAsync(UpdateRoomDto input)
        {
            CheckCreatePermission();

            Rooms room = ObjectMapper.Map<Rooms>(input);

            await roomsRepository.InsertAsync(room);

            return MapToEntityDto(room);
        }

        [AbpAllowAnonymous]
        public Task<ListResultDto<RoomDto>> GetAllRooms()
        {
            IQueryable<Rooms> roomsList = roomsRepository.GetAll();

            return Task.FromResult(
                new ListResultDto<RoomDto>(ObjectMapper.Map<List<RoomDto>>(roomsList).OrderBy(p => p.Name).ToList()));
        }

        public override async Task<RoomDto> UpdateAsync(RoomDto input)
        {
            CheckUpdatePermission();

            Rooms rooms = new()
                              {
                                  Category = input.Category, Image1 = input.Image1, 
                                  Image2 =  input.Image2,
                                  Image3 =  input.Image3,
                                  Image4 = input.Image4,
                                  Image5 = input.Image5,
                                  Name = input.Name,
                                  Bath = input.Bath, Bed = input.Bed, Description = input.Description
                              };
            rooms.Name = input.Name;
            rooms.ImageSequence = input.ImageSequence;
            rooms.Length = input.Length;
            rooms.Price = input.Price;
            rooms.Id = input.Id;

            await roomsRepository.UpdateAsync(rooms);

            return MapToEntityDto(rooms);
        }
    }
}