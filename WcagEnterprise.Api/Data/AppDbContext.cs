using Microsoft.EntityFrameworkCore;

namespace WcagEnterprise.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WcagRuleEntity> WcagRules => Set<WcagRuleEntity>();
    }
}