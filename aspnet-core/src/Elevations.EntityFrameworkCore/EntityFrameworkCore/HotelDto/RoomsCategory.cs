namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;

    [Table("RoomsCategory")]
    public class RoomsCategory : Entity, IHasCreationTime
    {
        [Required]
        public DateTime CreationTime { get; set; }

        public string Name { get; set; }
    }
}