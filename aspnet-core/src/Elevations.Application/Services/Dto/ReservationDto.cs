using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Elevations.EntityFrameworkCore.HotelDto;

namespace Elevations.Services.Dto
{
    [AutoMapFrom(typeof(Reservation))]
    public class ReservationDto : EntityDto<int>
    {
        public string Address { get; set; }

        public long CreatorUserId { get; set; }

        public string Email { get; set; }

        public int ImageSequence { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }
    }
}