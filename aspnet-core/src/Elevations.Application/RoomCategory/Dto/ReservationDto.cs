namespace Elevations.RoomCategory.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;

    [AutoMapFrom(typeof(Reservation))]
    public class ReservationDto : EntityDto<int>
    {
        public string Address { get; set; }

        public long CreatorUserId { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public int ImageSequence { get; set; }
    }
}