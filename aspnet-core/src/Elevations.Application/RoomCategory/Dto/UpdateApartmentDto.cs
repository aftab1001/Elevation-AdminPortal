namespace Elevations.RoomCategory.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    using Elevations.EntityFrameworkCore.HotelDto;

    public class UpdateApartmentDto : IEntityDto<int>
    {
        public UpdateApartmentDto()
        {
            ApartmentCategory = new ApartmentCategory();
        }

        public ApartmentCategory ApartmentCategory { get; set; }

        public long Bath { get; set; }

        public long Bed { get; set; }

        public DateTime CreationTime { get; set; }

        public long CreatorUserId { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Image { get; set; }

        public int ImageSequence { get; set; }

        public DateTime LastModificationTime { get; set; }

        public long LastModifierUserId { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }
    }
}