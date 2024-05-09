namespace mercantil_api.Models.Mercantil
{
    public class C2P_Request
    {
        public Merchant_Identify Merchant_Identify { get; set; }

        public Client_Identify Client_Identify { get; set; }

        public Transaction_C2P Transaction_C2P { get; set; }
    }
}
