﻿namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Dishes")]
    public class Dishes : AuditedEntity
    {
        public long Bath { get; set; }

        public long Bed { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        [Required]
        public int ImageSequence { get; set; }

        public long Length { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}