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

        public long CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CityFee { get; set; }

        public string CleaningFee { get; set; }

        [Required]
        public string Description { get; set; }

        public string Facilities { get; set; }

        public string Features { get; set; }

        [Required]
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        [Required]
        public int ImageSequence { get; set; }

        [Required]
        public long Length { get; set; }

        public string Location { get; set; }

        public string MaxNumberOfDays { get; set; }

        public string MinNumberOfDays { get; set; }

        public string MonthlyPlan { get; set; }

        [Required]
        public string Name { get; set; }

        public string NightlyPlan { get; set; }

        [Required]
        public string Price { get; set; }

        public string WeekendPlan { get; set; }

        public string WeeklyPlan { get; set; }
    }
}