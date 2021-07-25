namespace Elevations.Services.Dto
{
    using System;

    public class ProductDetail
    {
        public string BookingType { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string FName { get; set; }

        public int ItemId { get; set; }

        public string ItemType { get; set; }

        public string LastDate { get; set; }

        public string LName { get; set; }

        public decimal Price { get; set; }

        public decimal PricePaid { get; set; }

        public string SpecialRequest { get; set; }

        public DateTime StartDate { get; set; }
    }
}