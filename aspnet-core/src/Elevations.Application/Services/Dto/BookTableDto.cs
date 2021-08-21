namespace Elevations.Services.Dto
{
    using Abp.Application.Services.Dto;

    public class BookTableDto : EntityDto
    {
        public string Email { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public string NumberOfGuest { get; set; }
    }
}