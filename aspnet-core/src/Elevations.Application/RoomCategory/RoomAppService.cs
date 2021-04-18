﻿namespace Elevations.RoomCategory
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

    using Microsoft.EntityFrameworkCore;

    //  [AbpAuthorize(PermissionNames.Pages_Rooms)]
    [AbpAllowAnonymous]
    public class RoomAppService :
        AsyncCrudAppService<Rooms, RoomDto, int, PagedRoleResultRequestDto, UpdateRoomDto, RoomDto>,
        IRoomAppService
    {
        private readonly IRepository<RoomsCategory> roomsCategory;

        private readonly IRepository<Rooms> roomsRepository;

        public RoomAppService(IRepository<Rooms> roomsRepository, IRepository<RoomsCategory> roomsCategory)
            : base(roomsRepository)
        {
            this.roomsRepository = roomsRepository;
            this.roomsCategory = roomsCategory;
        }

        public override async Task<RoomDto> CreateAsync(UpdateRoomDto input)
        {
            CheckUpdatePermission();

            Rooms rooms = new()
                              {
                                  Category = roomsCategory.GetAll().FirstOrDefault(x => x.Name == input.CategoryName),
                                  Image1 = input.Image1, Image2 = input.Image2, Image3 = input.Image3,
                                  Image4 = input.Image4, Image5 = input.Image5, Name = input.Name, Bath = input.Bath,
                                  Bed = input.Bed,
                                  Description = string.IsNullOrEmpty(input.Description)
                                                    ? "create Room"
                                                    : input.Description
                              };
            rooms.Name = input.Name;
            rooms.ImageSequence = input.ImageSequence;
            rooms.Length = input.Length;
            rooms.Price = input.Price;
            rooms.Description = input.Description;

            rooms.Features = input.Features;
            rooms.Facilities = input.Facilities;
            rooms.Facilities = input.Facilities;
            rooms.WeekendPlan = input.WeekendPlan;
            rooms.WeeklyPlan = input.WeeklyPlan;
            rooms.MonthlyPlan = input.MonthlyPlan;
            rooms.CleaningFee = input.CleaningFee;
            rooms.CityFee = input.CityFee;
            rooms.MaxNumberOfDays = input.MaxNumberOfDays;
            rooms.MinNumberOfDays = input.MinNumberOfDays;

            int insertedId = await roomsRepository.InsertAndGetIdAsync(rooms);
            rooms.Id = insertedId;
            return MapToEntityDto(rooms);
        }

        [AbpAllowAnonymous]
        public Task<ListResultDto<RoomDto>> GetAllRooms()
        {
            IQueryable<Rooms> roomsList = roomsRepository.GetAllIncluding(x => x.Category);

            foreach (Rooms rooms in roomsList)
            {
                rooms.CategoryName = rooms.Category.Name;
            }

            return Task.FromResult(
                new ListResultDto<RoomDto>(ObjectMapper.Map<List<RoomDto>>(roomsList).OrderBy(p => p.Name).ToList()));
        }

        public override async Task<RoomDto> UpdateAsync(RoomDto input)
        {
            CheckUpdatePermission();

            Rooms rooms = new()
                              {
                                  Category = roomsCategory.GetAll().FirstOrDefault(x => x.Name == input.CategoryName),
                                  Image1 = input.Image1, Image2 = input.Image2, Image3 = input.Image3,
                                  Image4 = input.Image4, Image5 = input.Image5, Name = input.Name, Bath = input.Bath,
                                  Bed = input.Bed, Description = input.Description
                              };

            rooms.Name = input.Name;
            rooms.ImageSequence = input.ImageSequence;
            rooms.Length = input.Length;
            rooms.Price = input.Price;
            rooms.Id = input.Id;
            rooms.Description = input.Description;

            rooms.Features = input.Features;
            rooms.Facilities = input.Facilities;
            rooms.Facilities = input.Facilities;
            rooms.WeekendPlan = input.WeekendPlan;
            rooms.WeeklyPlan = input.WeeklyPlan;
            rooms.MonthlyPlan = input.MonthlyPlan;
            rooms.CleaningFee = input.CleaningFee;
            rooms.CityFee = input.CityFee;
            rooms.MaxNumberOfDays = input.MaxNumberOfDays;
            rooms.MinNumberOfDays = input.MinNumberOfDays;

            await roomsRepository.UpdateAsync(rooms);

            return MapToEntityDto(rooms);
        }

        protected override async Task<Rooms> GetEntityByIdAsync(int id)
        {
            Rooms filteredRoom =
                await roomsRepository.GetAllIncluding(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            filteredRoom.CategoryName = filteredRoom.Category.Name;
            filteredRoom.CategoryId = filteredRoom.Category.Id;
            return filteredRoom;
        }
    }
}