namespace Elevations.Services.Dto
{
    using Abp.Application.Services.Dto;

    public class FoundationDto : EntityDto<int>
    {
        public string Description { get; set; }

        public string HeadingText { get; set; }

        public string Image { get; set; }

        public string Type { get; set; }

        public string UpperText { get; set; }
    }
}