using mercantil_api.Models.Banks;
using mercantil_api.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace mercantil_api.Services.Payments
{
    public class PaymentsService
    {
        private readonly PaymentContext _paymentContext;
        public PaymentsService(PaymentContext paymentContext)
        {
            _paymentContext = paymentContext;
        }

        public async Task<int> Create(PaymentDTO newPayment)
        {
            var bank = _paymentContext
                .Banks
                .AsNoTracking()
                .FirstOrDefault(bank => bank.Id == newPayment.BankId);

            if (bank == null)
            {
                throw new Exception("Selected bank is invalid");
            }

            var payment = new Payment()
            {
                Amount = newPayment.Amount,
                Bank = bank,
                DestinationPhone = newPayment.DestinationPhone,
                Dni = newPayment.Dni,
                PaymentReference = newPayment.PaymentReference.PadLeft(11, '0'),
                InvoiceNumber = newPayment.InvoiceNumber.PadLeft(11, '0')
            };

            _paymentContext.Add(payment);

            return await _paymentContext.SaveChangesAsync();
        }
    }
}
