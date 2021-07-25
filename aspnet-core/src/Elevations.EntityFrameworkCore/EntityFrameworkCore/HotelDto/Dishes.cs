namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Dishes")]
    public class Dishes : AuditedEntity
    {
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public bool IsPopular { get; set; }

        public bool IsPoster { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}