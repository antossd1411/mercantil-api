using mercantil_api.Models.Banks;
using System.ComponentModel.DataAnnotations;

namespace mercantil_api.Models.Payments
{
    public class PaymentDTO
    {
        public int Id { get; set; } = 0;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int BankId { get; set; } = new();

        [Required]
        [MaxLength(11)]
        public string? DestinationPhone { get; set; }

        [Required]
        [MaxLength(11)]
        public string? Dni { get; set; }

        [Required]
        [MaxLength(11)]
        public string? PaymentReference { get; set; }

        [Required]
        [MaxLength(11)]
        public string? InvoiceNumber { get; set; }

        public string? CreatedAt { get; set; }

        public string? UpdatedAt { get; set; }
    }
}
