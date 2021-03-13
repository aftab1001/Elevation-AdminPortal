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

        [ForeignKey(nameof(RoomsCategory))]
        public RoomsCategory Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int ImageSequence { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }
    }
}