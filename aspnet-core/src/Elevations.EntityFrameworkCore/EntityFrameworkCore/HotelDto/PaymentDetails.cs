namespace Elevations.EntityFrameworkCore.HotelDto
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Abp.Domain.Entities;

    [Table("PaymentDetails")]
    public class PaymentDetails : Entity
    {
        public string TransactionId { get; set; }
    }
}