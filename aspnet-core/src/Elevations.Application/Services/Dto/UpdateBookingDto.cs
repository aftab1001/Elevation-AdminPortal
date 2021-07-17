namespace Elevations.Services.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    using Elevations.EntityFrameworkCore.HotelDto;

    public class UpdateBookingDto : EntityDto
    {
        public string AdminComments { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public BookingType BookingType { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public DateTime FromDate { get; set; }

        public int Id { get; set; }

        public long ItemId { get; set; }

        public ItemType ItemType { get; set; }

        public string LastName { get; set; }

        public double Price { get; set; }

        public string SpecialRequest { get; set; }

        public DateTime ToDate { get; set; }

        public string PaymentReferenceId { get; set; }
    }
}