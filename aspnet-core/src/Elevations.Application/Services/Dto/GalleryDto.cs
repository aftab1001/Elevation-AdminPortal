using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Elevations.EntityFrameworkCore.HotelDto;

namespace Elevations.Services.Dto
{
    [AutoMapFrom(typeof(Gallery))]
    public class GalleryDto : EntityDto<int>
    {
        public string Image { get; set; }

        public string ImageTitle { get; set; }


        public string Type { get; set; }

        public int Id { get; set; }
    }
}