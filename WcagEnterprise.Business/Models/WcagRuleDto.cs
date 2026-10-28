namespace WcagEnterprise.Business.Models
{
    public class WcagRuleDto
    {
        public int Id { get; set; }
        public string? Principle { get; set; }
        public string? Guideline { get; set; }
        public string? Description { get; set; }
        public string? ComplianceLevel { get; set; }
    }
}