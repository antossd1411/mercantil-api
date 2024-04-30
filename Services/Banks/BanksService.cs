using mercantil_api.Models.Banks;
using mercantil_api.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace mercantil_api.Services.Banks
{
    public class BanksService
    {
        private readonly PaymentContext _paymentContext;

        public BanksService(PaymentContext paymentContext) { _paymentContext = paymentContext; }

        public IEnumerable<Bank> GetAll()
        {
            return _paymentContext
                .Banks
                .AsNoTracking()
                .ToList();
        }
    }
}
