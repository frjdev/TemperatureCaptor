using Microsoft.EntityFrameworkCore;

namespace Temperature.Infrastructure.Tests;

public class TemperatureRepositoryTests
{
    private static DbContextOptions<TemperatureContext> ConnectToSqLiteDatabaseProduction()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var dataBaseDirectory = $@"{Directory.GetParent(workingDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName}\src\Temperature.WebAPI";

        var DbPath = Path.Join(dataBaseDirectory, "Temperature.db");

        var _contextOptions = new DbContextOptionsBuilder<TemperatureContext>()
                        .UseSqlite($"DataSource={DbPath}")
                        .Options;

        return _contextOptions;
    }

    [Fact]
    public async void ShouldBeAbleToReturnTheLast15Temperature()
    {
        var options = ConnectToSqLiteDatabaseProduction();

        await using var temperatureContext = new TemperatureContext(options);
        var temperatureRepository = new TemperatureRepository(temperatureContext, new TemperatureCaptorGenerator());
        var actual = await temperatureRepository.GetLast15TempAsync();
        Assert.Equal(15, actual.Count);
    }
    [Fact]
    public async void ShouldBeAbleToUpdateHotRangeTemperature()
    {
        var options = ConnectToSqLiteDatabaseProduction();
        var expectedStart = 35;
        var expectedEnd = 60;

        await using var temperatureContext = new TemperatureContext(options);
        var temperatureRepository = new TemperatureRepository(temperatureContext, new TemperatureCaptorGenerator());
        var result = await temperatureRepository.UpdateRangeStateAsync("HOT", expectedStart, expectedEnd);
        Assert.True(result);

        await using var verifyTemperatureContext = new TemperatureContext(options);
        var warmTemperaturesRange = await verifyTemperatureContext.TemperatureRangeSet.FirstOrDefaultAsync(x => x.State == "WARM");
        Assert.Equal(expectedStart, warmTemperaturesRange!.End);
    }
    [Fact]
    public async void ShouldBeAbleToUpdateColdRangeTemperature()
    {
        var options = ConnectToSqLiteDatabaseProduction();
        var expectedStart = 15;
        var expectedEnd = -60;

        await using var temperatureContext = new TemperatureContext(options);
        var temperatureRepository = new TemperatureRepository(temperatureContext, new TemperatureCaptorGenerator());
        var result = await temperatureRepository.UpdateRangeStateAsync("COLD", expectedStart, expectedEnd);
        Assert.True(result);

        await using var verifyTemperatureContext = new TemperatureContext(options);
        var warmTemperaturesRange = await verifyTemperatureContext.TemperatureRangeSet.FirstOrDefaultAsync(x => x.State == "WARM");
        Assert.Equal(expectedStart, warmTemperaturesRange!.Start);
    }
    [Fact]
    public async void ShouldBeAbleToUpdateWarmRangeTemperature()
    {
        var options = ConnectToSqLiteDatabaseProduction();
        var expectedStart = 20;
        var expectedEnd = 30;

        await using var temperatureContext = new TemperatureContext(options);
        var temperatureRepository = new TemperatureRepository(temperatureContext, new TemperatureCaptorGenerator());
        var result = await temperatureRepository.UpdateRangeStateAsync("WARM", expectedStart, expectedEnd);
        Assert.True(result);

        await using var verifyTemperatureContext = new TemperatureContext(options);
        var hotTemperaturesRange = await verifyTemperatureContext.TemperatureRangeSet.FirstOrDefaultAsync(x => x.State == "HOT");
        var coldTemperaturesRange = await verifyTemperatureContext.TemperatureRangeSet.FirstOrDefaultAsync(x => x.State == "COLD");
        Assert.Equal(expectedEnd, hotTemperaturesRange!.Start);
        Assert.Equal(expectedStart, coldTemperaturesRange!.Start);
    }
    [Fact]
    public async void ShouldBeAbleToCreateANewTemperature()
    {
        var options = ConnectToSqLiteDatabaseProduction();
        var temperature = 15;
        var state = "WARM";

        await using var temperatureContext = new TemperatureContext(options);
        var temperatureRepository = new TemperatureRepository(temperatureContext, new TemperatureCaptorGenerator());

        var expected = await temperatureRepository.CreateTemperatureAsync(temperature, state);

        Assert.NotNull(expected);

        await using var verifyTemperatureContext = new TemperatureContext(options);
        var actual = verifyTemperatureContext.TemperatureSet.OrderBy(x => x.Id).LastOrDefault();

        Assert.NotNull(actual);

        Assert.Equal(expected, TemperatureData.ToDomain(actual!));
    }

}
