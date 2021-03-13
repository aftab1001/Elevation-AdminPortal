namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Rooms")]
    public class Rooms : AuditedEntity
    {
        public Rooms()
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