namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Apartments")]
    public class Apartments : AuditedEntity
    {
        public Apartments()
        {
            CreationTime = DateTime.Now;
        }

        [Required]
        public long Bath { get; set; }

        [Required]
        public long Bed { get; set; }

        [ForeignKey(nameof(ApartmentCategory))]
        public ApartmentCategory Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int ImageSequence { get; set; }

        [Required]
        public long Length { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }
    }
}