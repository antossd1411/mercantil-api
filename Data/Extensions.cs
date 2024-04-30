using mercantil_api.Models.Payments;

namespace mercantil_api.Data
{
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PaymentContext>();
                context.Database.EnsureCreated();
                DBInitializer.Initialize(context);
            };
        }
    }
}
