using PremiumCalculator.UI.Calculator.Constants;
using PremiumCalculator.UI.Calculator.Models;
using PremiumCalculator.UI.Calculator.Models.ViewModel;
using PremiumCalculator.UI.Calculator.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PremiumCalculator.UI.Calculator.Services
{
    public class OccupationService: IOccupationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OccupationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ??
              throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public async Task<PremiumViewModel> GetOccupationList()
        {
            var premiumViewModel = new PremiumViewModel
            {
                Occupation = await GetOccupations()
            };
            return premiumViewModel;
        }

        public async Task<List<OccupationFactor>> GetOccupations()
        {
            var result = new List<OccupationFactor>();
            try
            {
                var httpClient = _httpClientFactory.CreateClient(UtilityConstant.OccupationServiceName);
                var response = await httpClient.GetAsync(UtilityConstant.OccupationServicePath);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    result = JsonSerializer.Deserialize<List<OccupationFactor>>(content, options);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}
