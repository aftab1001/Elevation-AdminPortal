namespace Elevations.Services.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;

    [AutoMapFrom(typeof(Dishes))]
    public class DishesDto : EntityDto<int>
    {
        public DishCategory Category { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public enum DishCategory
    {
        Default,

        Popular,

        Poster
    }
}