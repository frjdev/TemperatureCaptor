using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Temperature.Infrastructure;
public class TemperatureContextFactory : IDesignTimeDbContextFactory<TemperatureContext>
{
    public TemperatureContext CreateDbContext(string[] args)
    {
        var workingDirectory = Environment.CurrentDirectory;
        var dataBaseDirectory = $@"{Directory.GetParent(workingDirectory)!.FullName}\Temperature.Infrastructure";

        var DbPath = Path.Join(dataBaseDirectory, "Temperature.db");

        var optionsBuilder = new DbContextOptionsBuilder<TemperatureContext>();
        optionsBuilder.UseSqlite($"DataSource={DbPath}");

        return new TemperatureContext(optionsBuilder.Options);
    }
}
