using Microsoft.EntityFrameworkCore;
using WcagEnterprise.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("EnterpriseDb"));

var app = builder.Build();

// Ensure DB is created and seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    await DbInitializer.SeedAsync(context);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();