namespace Elevations.MultiTenancy.Dto
{
    using Abp.Application.Services.Dto;

    public class PagedTenantResultRequestDto : PagedResultRequestDto
    {
        public bool? IsActive { get; set; }

        public string Keyword { get; set; }
    }
}