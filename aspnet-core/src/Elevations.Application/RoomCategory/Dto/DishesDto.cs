namespace Elevations.RoomCategory.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;

    [AutoMapFrom(typeof(Dishes))]
    public class DishesDto : EntityDto<int>
    {
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

        public decimal Price { get; set; }
    }
}