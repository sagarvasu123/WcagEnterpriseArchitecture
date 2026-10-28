using WcagEnterprise.Business.Models;

namespace WcagEnterprise.Business.Services
{
    public interface IWcagService
    {
        Task<IEnumerable<WcagRuleDto>> GetComplianceRulesAsync();
        Task<bool> AddRuleAsync(WcagRuleDto rule);
    }
}