using Abp.Application.Services.Dto;

namespace Elevations.Services.Dto
{
    public class UpdateGalleryDto : IEntityDto<int>
    {
        public string Image { get; set; }

        public string ImageTitle { get; set; }

        public string Type { get; set; }

        public int Id { get; set; }
    }
}