using Microsoft.EntityFrameworkCore;

namespace mercantil_api.Models.Banks
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }

        public DbSet<Bank> Banks { get; set; }
    }
}
