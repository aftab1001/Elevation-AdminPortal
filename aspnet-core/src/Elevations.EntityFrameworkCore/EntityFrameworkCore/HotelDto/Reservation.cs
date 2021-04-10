namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Reservation")]
    public class Reservation : AuditedEntity
    {
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        public string Message { get; set; }

        [Required]
        public string Name { get; set; }
    }
}