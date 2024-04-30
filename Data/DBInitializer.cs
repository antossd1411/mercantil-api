using mercantil_api.Models.Banks;
using mercantil_api.Models.Payments;

namespace mercantil_api.Data
{
    public static class DBInitializer
    {
        public static void Initialize(PaymentContext context)
        {
            if (!context.Banks.Any())
            {
                var banks = new Bank[]
                {
                    new Bank { Id = 1, Name = "Mercantil", Code = "0105"},
                    new Bank { Id = 2, Name = "Banesco", Code = "0134"},
                    new Bank { Id = 3, Name = "Banco Nacional de Crédito", Code = "0191"},
                    new Bank { Id = 4, Name = "Bicentenario", Code = "0175"},
                    new Bank { Id = 5, Name = "Bancamiga", Code = "0172"}
                };

                context.Banks.AddRange(banks);
                context.SaveChanges();
            }
        }
    }
}
