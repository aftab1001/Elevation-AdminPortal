namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Dashboard")]
    public class Dashboard : AuditedEntity
    {
        public long Bath { get; set; }

        public long Bed { get; set; }

        [Required]
        public string Description1 { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int ImageSequence { get; set; }

        public long Length { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Title { get; set; }
    }
}