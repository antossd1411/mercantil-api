using mercantil_api.Models.Mercantil;
using mercantil_api.Models.Payments;
using Microsoft.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace mercantil_api.Services.Mercantil
{
    public class MercantilService
    {
        C2P_Request request = new();
        private readonly IHttpClientFactory httpClientFactory;
        private readonly HttpRequestMessage httpRequestMessage;

        public MercantilService(IHttpClientFactory _httpClientFactory, IConfiguration configuration)
        {
            var configSection = configuration.GetSection("Mercantil");

            httpRequestMessage = new(HttpMethod.Post, configSection["API_URL"])
            {
                Headers =
                {
                    {HeaderNames.Accept, "application/json"},
                    {"X-IBM-Client-Id", configSection["ClientId"]}
                }
            };

            request.Merchant_Identify = new(configSection["IntegratorId"], configSection["MerchantId"], configSection["TerminalId"]);

            httpClientFactory = _httpClientFactory;
        }

        public async void Pay(PaymentDTO newPayment)
        {
            request.Transaction_C2P = new()
            {
                Destination_Id = Encrypt(newPayment.Dni),
                Invoice_Number = newPayment.InvoiceNumber,
                Amount = newPayment.Amount,
                Destination_Bank_Id = newPayment.BankCode,
                Destination_Mobile_Number = Encrypt(newPayment.DestinationPhone),
                PaymentReference = newPayment.PaymentReference.PadLeft(11, '0'),
                Origin_Mobile_Number = Encrypt(string.Empty)
            };

            var requestJson = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            httpRequestMessage.Content = requestJson;

            var httpClient = httpClientFactory.CreateClient();

            var responseMessage = await httpClient.SendAsync(httpRequestMessage);

            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    await responseMessage.Content.ReadAsStringAsync();
            //} else
            //{
            //}
        }

        private byte[] HashKey(string secretKey)
        {
            byte[] key = new byte[16];

            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(secretKey));
                Array.Copy(hash, key, 16);
            }

            return key;
        }
        private string Encrypt(string data)
        {
            byte[] array;
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = HashKey(string.Empty);
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.ECB;

                ICryptoTransform encryptor = aes.CreateEncryptor();

                using(MemoryStream stream = new())
                {
                    using(CryptoStream cryptoStream = new(stream, encryptor, CryptoStreamMode.Write))
                    {
                        using(StreamWriter writer = new(cryptoStream))
                        {
                            writer.Write(data);
                        }

                        array = stream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
    }
}
