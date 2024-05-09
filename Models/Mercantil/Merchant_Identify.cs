namespace mercantil_api.Models.Mercantil
{
    public class Merchant_Identify
    {
        public Merchant_Identify(string _IntegratorId, string _MerchantId, string _TerminalId)
        {
            IntegratorId = _IntegratorId;
            MerchantId = _MerchantId;
            TerminalId = _TerminalId;
        }

        public string IntegratorId { get; set; }

        public string MerchantId { get; set; }

        public string TerminalId { get; set; }
    }
}
