﻿namespace Elevations.Services.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;

    [AutoMapFrom(typeof(Reservation))]
    public class ReservationDto : EntityDto<int>
    {
        public string Email { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public string NumberOfGuest { get; set; }
    }
}