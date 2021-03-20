namespace Elevations.RoomCategory.Dto
{
    using System;

    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.EntityFrameworkCore.HotelDto;

    [AutoMapFrom(typeof(News))]
    public class NewsDto:EntityDto<int>
    {
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int ImageSequence { get; set; }

        public string Title { get; set; }
    }
}