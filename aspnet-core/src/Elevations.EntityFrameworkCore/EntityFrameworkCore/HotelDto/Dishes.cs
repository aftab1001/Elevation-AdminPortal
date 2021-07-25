namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Dishes")]
    public class Dishes : AuditedEntity
    {
        public int Category { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

 
}