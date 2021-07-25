namespace Elevations.Services.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class PayModel
    {
        public string Address { get; set; }

        [Required]
        public int Amount { get; set; }

        public string Contact { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Email { get; set; }

        public PaymentData PaymentData { get; set; }

        public string Phone { get; set; }

        public ProductDetail ProductInfo { get; set; }
    }
}