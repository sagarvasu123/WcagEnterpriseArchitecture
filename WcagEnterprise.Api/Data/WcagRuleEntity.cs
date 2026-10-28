using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WcagEnterprise.Api.Data
{
    public class WcagRuleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Principle { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Guideline { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string ComplianceLevel { get; set; } = "AA";
    }
}