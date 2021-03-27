namespace Elevations.RoomCategory.Dto
{
    using System;

    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;

    [AutoMapFrom(typeof(Apartments))]
    public class ApartmentDto : EntityDto<int>
    {
        public DateTime CreationTime { get; set; }

        public long CreatorUserId { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public long ImageSequence { get; set; }

        public DateTime LastModificationTime { get; set; }

        public long LastModifierUserId { get; set; }

        public string Name { get; set; }

        public long Bed { get; set; }

        public long Length { get; set; }

        public long Bath { get; set; }

        public string Price { get; set; }

        public ApartmentCategory ApartmentCategory { get; set; }
        
    }
}