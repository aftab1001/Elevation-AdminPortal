namespace Elevations.Services.Dto
{
    using Abp.Application.Services.Dto;

    public class BookingDetailsDto : EntityDto
    {
        public string Name { get; set; }

        public string Price { get; set; }
    }
}