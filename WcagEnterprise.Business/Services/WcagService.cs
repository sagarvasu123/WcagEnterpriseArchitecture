using System.Net.Http.Json;
using WcagEnterprise.Business.Models;

namespace WcagEnterprise.Business.Services
{
    public class WcagService : IWcagService
    {
        private readonly HttpClient _httpClient;

        public WcagService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WcagRuleDto>> GetComplianceRulesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<WcagRuleDto>>("api/rules");
            return response ?? Enumerable.Empty<WcagRuleDto>();
        }

        public async Task<bool> AddRuleAsync(WcagRuleDto rule)
        {
            var response = await _httpClient.PostAsJsonAsync("api/rules", rule);
            return response.IsSuccessStatusCode;
        }
    }
}