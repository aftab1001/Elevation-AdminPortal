namespace Elevations.RoomCategory.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;

    [AutoMapFrom(typeof(Apartments))]
    public class ApartmentDto : EntityDto<int>
    {
        public ApartmentDto()
        {
            ApartmentCategory = new ApartmentCategory();
        }

        public ApartmentCategory ApartmentCategory { get; set; }

        public long Bath { get; set; }

        public long Bed { get; set; }

        public string Description { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        public int ImageSequence { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }
    }
}