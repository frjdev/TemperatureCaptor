using HelpersTests;
using Microsoft.EntityFrameworkCore;

namespace Temperature.Infrastructure.Tests;

public class TemperatureRepositoryTests
{
    private static DbContextOptions<TemperatureContext> BuildSqLiteDatabaseWithInitialData()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var dataBaseDirectory = $@"{Directory.GetParent(workingDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName}\src\Temperature.Infrastructure";

        var DbPath = Path.Join(dataBaseDirectory, "Temperature.db");

        var _contextOptions = new DbContextOptionsBuilder<TemperatureContext>()
                        .UseSqlite($"DataSource={DbPath}")
                        .Options;

        return _contextOptions;
    }

    [Fact]
    public async void ShouldBeAbleToReturnTheLast15Temperature()
    {
        var options = BuildSqLiteDatabaseWithInitialData();

        await using var temperatureContext = new TemperatureContext(options);
        {
            var temperatureRepository = new TemperatureRepository(temperatureContext, new TemperatureCaptorGenerator());

            var actual = await temperatureRepository.GetHistoricTempAsync();

            Assert.Equal(15, actual.Count);
        }
    }
    [Fact]
    public async void ShouldBeAbleToUpdateHotRangeTemperature()
    {
        var options = BuildSqLiteDatabaseWithInitialData();
        var expectedStart = 35;
        var expectedEnd = 60;

        await using var temperatureContext = new TemperatureContext(options);
        {
            var temperatureRepository = new TemperatureRepository(temperatureContext, new TemperatureCaptorGenerator());

            var result = await temperatureRepository.UpdateRangeStateAsync("HOT", expectedStart, expectedEnd);

            Assert.True(result);
        }

        await using var verifyTemperatureContext = new TemperatureContext(options);
        {
            var warmTemperaturesRange = await verifyTemperatureContext.TemperatureRangeSet.FirstOrDefaultAsync(x => x.State == "WARM");

            Assert.Equal(expectedStart, warmTemperaturesRange!.End);
        }
    }
}
