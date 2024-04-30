using mercantil_api.Models.Banks;
using Microsoft.EntityFrameworkCore;

namespace mercantil_api.Models.Payments
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .Property(p => p.CreatedAt)
                .HasDefaultValue(DateTime.Now);
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Bank> Banks { get; set; }
    }
}
