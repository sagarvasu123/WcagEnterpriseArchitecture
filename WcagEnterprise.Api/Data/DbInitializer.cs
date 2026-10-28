using Microsoft.EntityFrameworkCore;

namespace WcagEnterprise.Api.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (await context.WcagRules.AnyAsync())
            {
                return; // DB has already been seeded
            }

            var initialRules = new List<WcagRuleEntity>
            {
                new()
                {
                    Principle = "Perceivable",
                    Guideline = "1.4.3 Contrast (Minimum)",
                    Description = "The visual presentation of text and images of text has a contrast ratio of at least 4.5:1.",
                    ComplianceLevel = "AA"
                },
                new()
                {
                    Principle = "Operable",
                    Guideline = "2.1.1 Keyboard Accessible",
                    Description = "All functionality of the content is operable through a keyboard interface without requiring specific timings for individual keystrokes.",
                    ComplianceLevel = "A"
                },
                new()
                {
                    Principle = "Understandable",
                    Guideline = "3.3.2 Labels or Instructions",
                    Description = "Labels or instructions are provided when content requires user input to prevent form submission errors.",
                    ComplianceLevel = "A"
                },
                new()
                {
                    Principle = "Robust",
                    Guideline = "4.1.2 Name, Role, Value",
                    Description = "For all user interface components, the name and role can be programmatically determined; states, properties, and values can be set programmatically.",
                    ComplianceLevel = "AA"
                }
            };

            await context.WcagRules.AddRangeAsync(initialRules);
            await context.SaveChangesAsync();
        }
    }
}