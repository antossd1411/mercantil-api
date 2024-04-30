using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mercantil_api.Models.Banks
{
    public class Bank
    {
        [MaxLength(11)]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [Required, MaxLength(4)]
        public string? Code { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}
