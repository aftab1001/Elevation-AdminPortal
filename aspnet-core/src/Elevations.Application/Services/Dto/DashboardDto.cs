using Abp.Application.Services.Dto;

namespace Elevations.Services.Dto
{
    public class DashboardDto : EntityDto<int>
    {
        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Image { get; set; }

        public int ImageSequence { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }
    }
}