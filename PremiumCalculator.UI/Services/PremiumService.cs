using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PremiumCalculator.UI.Calculator.Constants;
using PremiumCalculator.UI.Calculator.Models;
using PremiumCalculator.UI.Calculator.Models.ViewModel;
using PremiumCalculator.UI.Calculator.Services.Interface;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.UI.Calculator.Services
{
    public class PremiumService: IPremiumService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration config;
        public string CalculatePremiumApiUrl { get; set; }
        public PremiumService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            this.config = config;
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<PremiumResult> GetPremium(PremiumViewModel premium, CancellationToken cancellationToken)
        {
            var result = new PremiumResult();

            try
            {
                var httpClient = _httpClientFactory.CreateClient(UtilityConstant.PremiumServiceName);
                var premiumModel = new PremiumModel
                {
                    Age = Convert.ToInt32(premium.Age),
                    FactorRating = Convert.ToDecimal(premium.FactorRating),
                    SumInsured = Convert.ToDecimal(premium.SumInsured)
                };
                var stringContent = new StringContent(JsonConvert.SerializeObject(premiumModel), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(UtilityConstant.PremiumServicePath, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    result = System.Text.Json.JsonSerializer.Deserialize<PremiumResult>(content, options);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }
    }
}
