using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Temperature.Infrastructure;

namespace Temperature.WebAPI.Tests;

public class TestWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TemperatureContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<TemperatureContext>(options =>
            {
                var workingDirectory = Environment.CurrentDirectory;
                var dataBaseDirectory = $@"{Directory.GetParent(workingDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName}\src\Temperature.WebAPI";

                var DbPath = Path.Join(dataBaseDirectory, "Temperature.db");
                options.UseSqlite($"DataSource={DbPath}");
            });
        });

        return base.CreateHost(builder);
    }
}
