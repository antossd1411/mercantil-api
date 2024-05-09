namespace mercantil_api.Models.Mercantil
{
    public class Transaction_C2P
    {
        public readonly string Trx_Type = "vuelto";

        public readonly string Payment_Method = "c2p";

        public string Destination_Id { get; set; }

        public string Invoice_Number { get; set; }

        public readonly string Currency = "VES";
        
        public decimal Amount { get; set; }

        public string Destination_Bank_Id { get; set; }

        public string Destination_Mobile_Number { get; set; }

        public string PaymentReference { get; set; }

        public string Origin_Mobile_Number { get; set; }

        public string TwoFactor_Auth = string.Empty;
    }
}
