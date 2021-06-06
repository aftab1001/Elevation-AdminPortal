﻿namespace Elevations.Roles.Dto
{
    using AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Services.Dto;

    public class FoundationMap : Profile
    {
        public FoundationMap()
        {
            CreateMap<Foundation, FoundationDto>();
        }
    }
}