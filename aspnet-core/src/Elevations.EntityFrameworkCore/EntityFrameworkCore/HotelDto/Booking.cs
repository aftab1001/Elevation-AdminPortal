namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities.Auditing;

    [Table("Booking")]
    public class Booking : AuditedEntity
    {
        public string AdminComments { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public BookingType BookingType { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        public long ItemId { get; set; }

        public ItemType ItemType { get; set; }

        public string LastName { get; set; }

        [ForeignKey(nameof(PaymentDetails))]
        public PaymentDetails PaymentReference { get; set; }

        public double Price { get; set; }

        public string RoomName { get; set; }

        public string SpecialRequest { get; set; }

        [Required]
        public DateTime ToDate { get; set; }
    }
}