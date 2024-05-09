using mercantil_api.Models.Banks;
using mercantil_api.Models.Payments;
using mercantil_api.Services.Mercantil;
using Microsoft.EntityFrameworkCore;

namespace mercantil_api.Services.Payments
{
    public class PaymentsService
    {
        private readonly PaymentContext _paymentContext;
        private readonly MercantilService _mercantilService;

        public PaymentsService(PaymentContext paymentContext, MercantilService mercantilService)
        {
            _paymentContext = paymentContext;
            _mercantilService = mercantilService;
        }

        public async Task<int> Create(PaymentDTO newPayment)
        {
            var bank = _paymentContext
                .Banks
                .AsNoTracking()
                .FirstOrDefault(bank => bank.Code == newPayment.BankCode);

            if (bank == null)
            {
                throw new Exception("Selected bank is invalid");
            }

            _mercantilService.Pay(newPayment);

            //var payment = new Payment()
            //{
            //    Amount = newPayment.Amount,
            //    Bank = bank,
            //    DestinationPhone = newPayment.DestinationPhone,
            //    Dni = newPayment.Dni,
            //    PaymentReference = newPayment.PaymentReference.PadLeft(11, '0'),
            //    InvoiceNumber = newPayment.InvoiceNumber.PadLeft(11, '0')
            //};

            //_paymentContext.Add(payment);

            //return await _paymentContext.SaveChangesAsync();
            return 1;
        }
    }
}
