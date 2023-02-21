using HelpersTests;
using Microsoft.EntityFrameworkCore;

namespace Temperature.Infrastructure.Tests;

public class TemperatureRepositoryTests
{
    private static async Task<DbContextOptions<TemperatureContext>> BuildSqLiteDatabaseWithInitialDataAsync()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var dataBaseDirectory = $@"{Directory.GetParent(workingDirectory)!.FullName}\Temperature.Infrastructure";

        var DbPath = Path.Join(dataBaseDirectory, "Temperature.db");


        var _contextOptions = new DbContextOptionsBuilder<TemperatureContext>()
                        .UseSqlite($"DataSource={DbPath}")
                        .Options;

        await using var temperatureContext = new TemperatureContext(_contextOptions);

        var ensureDeleted = await temperatureContext.Database.EnsureDeletedAsync();

        Assert.True(ensureDeleted);

        var ensureCreated = await temperatureContext.Database.EnsureCreatedAsync();

        Assert.True(ensureCreated);

        var itemsTemperatures = Samples.temperatures.Select(FromDomain).ToList();

        await temperatureContext.TemperatureSet.AddRangeAsync(itemsTemperatures!);
        var writtenState = await temperatureContext.SaveChangesAsync();

        Assert.Equal(writtenState, itemsTemperatures.Count);

        var itemsTemperaturesRange = Samples.temperaturesRange.Select(TempRangeFromDomain).ToList();
        await temperatureContext.TemperatureRangeSet.AddRangeAsync(itemsTemperaturesRange!);
        var writtenStateRange = await temperatureContext.SaveChangesAsync();

        Assert.Equal(writtenStateRange, itemsTemperaturesRange.Count);

        return _contextOptions;
    }
    private static TemperatureData? FromDomain(Domain.Temperature? temperature)
          => new TemperatureData()
          {
              Temp = temperature!.Temp,
              State = temperature.State,
              Date = temperature.Date
          };
    private static TemperatureDataRange? TempRangeFromDomain(Domain.TemperatureRange? temperature)
        => new TemperatureDataRange()
        {
            State = temperature!.State,
            Start = temperature.Start,
            End = temperature.End
        };
}
