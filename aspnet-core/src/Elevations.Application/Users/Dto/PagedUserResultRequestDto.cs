namespace Elevations.Users.Dto
{
    using Abp.Application.Services.Dto;

    //custom PagedResultRequestDto
    public class PagedUserResultRequestDto : PagedResultRequestDto
    {
        public bool? IsActive { get; set; }

        public string Keyword { get; set; }
    }
}