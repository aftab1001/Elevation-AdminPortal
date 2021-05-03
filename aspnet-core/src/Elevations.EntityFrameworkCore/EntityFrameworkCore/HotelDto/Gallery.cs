using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Elevations.EntityFrameworkCore.HotelDto
{
    [Table("Gallery")]
    public class Gallery : AuditedEntity
    {
        [Required] public string Image { get; set; }

        public string ImageTitle { get; set; }        

        public string ImageType { get; set; }
    }
}