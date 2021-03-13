namespace Elevations.RoomCategory.Dto
{
    using System;

    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;

    [AutoMapFrom(typeof(Rooms))]
    public class RoomDto: EntityDto<int>
    {
        public DateTime CreationTime { get; set; }

        public long CreatorUserId { get; set; }

        public string Description { get; set; }

        public long Id { get; set; }

        public string Image { get; set; }

        public long ImageSequence { get; set; }

        public DateTime LastModificationTime { get; set; }

        public long LastModifierUserId { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public RoomsCategory RoomCategoryName { get; set; }

        public long RoomsCategory { get; set; }
    }
}