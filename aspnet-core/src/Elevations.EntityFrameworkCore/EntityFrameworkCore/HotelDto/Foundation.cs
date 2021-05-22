using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Elevations.EntityFrameworkCore.HotelDto
{
    [Table("Foundation")]
    public class Foundation : AuditedEntity
    {
        public string Image { get; set; }

        public string UpperText { get; set; }
        public string HeadingText { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
   
    }
}