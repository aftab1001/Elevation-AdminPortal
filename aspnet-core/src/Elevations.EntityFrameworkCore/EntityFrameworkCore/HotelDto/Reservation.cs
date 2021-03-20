namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Authorization.Users;
    using Abp.Domain.Entities.Auditing;

    using Elevations.Authorization.Users;

    [Table("Reservation")]
    public class Reservation : AuditedEntity
    {
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public string Message { get; set; }

        [Required]
        public string Name { get; set; }

        
    }
}