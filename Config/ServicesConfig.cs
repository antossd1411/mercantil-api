using mercantil_api.Services.Banks;
using mercantil_api.Services.Payments;

namespace mercantil_api.Config
{
    public static class ServicesConfig
    {
        public static void InitializeServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<PaymentsService>();
            builder.Services.AddTransient<BanksService>();
        }
    }
}
