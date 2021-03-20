namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Dashboard")]
    public class Dashboard : AuditedEntity
    {

        [Required]
        public string Description1 { get; set; }

        public string Description2 { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int ImageSequence { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Title { get; set; }
    }
}