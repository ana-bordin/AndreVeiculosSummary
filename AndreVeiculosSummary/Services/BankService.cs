using Models;
using System.Text;
using Newtonsoft.Json;

namespace AndreVeiculosSummary.Services
{
    public class BankService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        //private readonly string _baseUrl = "https://localhost:5001/api/Bank";

        public async Task<Bank> PostBank(Bank bank)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await BankService._httpClient.PostAsync("https://localhost:7162/api/Bank", content);

                response.EnsureSuccessStatusCode();
                string bankResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Bank>(bankResponse);               
            }
            catch (Exception)
            {

                throw;
            }
            return bank;
        }
    }
}
