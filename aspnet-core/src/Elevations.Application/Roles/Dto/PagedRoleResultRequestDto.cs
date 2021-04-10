namespace Elevations.Roles.Dto
{
    using Abp.Application.Services.Dto;

    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}