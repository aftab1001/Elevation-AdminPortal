using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Elevations.EntityFrameworkCore.HotelDto;

namespace Elevations.Services.Dto
{
    [AutoMapFrom(typeof(News))]
    public class NewsDto : EntityDto<int>
    {
        public DateTime Date { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string Description4 { get; set; }

        public string Description5 { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        public int ImageSequence { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
    }
}