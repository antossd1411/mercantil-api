using mercantil_api.Models.Banks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace mercantil_api.Models.Payments
{
    public class Payment
    {
        [MaxLength(11)]
        public int Id { get; set; } = 0;

        [Precision(9,2)]
        public decimal Amount { get; set; }

        public Bank Bank { get; set; } = new();

        [Required, MaxLength(11)]
        public string? DestinationPhone { get; set; }

        [Required, MaxLength(11)]
        public string? Dni { get; set; }

        [Required, MaxLength(11)]
        public string? PaymentReference { get; set; }

        [Required, MaxLength(11)]
        public string? InvoiceNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
