namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("News")]
    public class News: AuditedEntity
    {
        public DateTime Date { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int ImageSequence { get; set; }

        [Required]
        public string Title { get; set; }
    }
}