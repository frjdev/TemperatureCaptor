using System.Collections.Immutable;
using HelpersTests;
using Moq;

namespace Temperature.Domain.Tests;

public class TemperatureServiceTest
{
    [Fact]
    public async Task ShouldBeAbleToReturnATemperature()
    {
        var expected = Samples.temperatures.FirstOrDefault();
        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.GetTemperatureAsync()).ReturnsAsync(expected);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.GetTemperatureAsync().ConfigureAwait(false);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task ShouldBeAbleToReturnTheHisotricsOfLast15Temperature()
    {
        var expected = Samples.temperatures.ToImmutableList();

        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.GetHistoricTempAsync())!.ReturnsAsync(expected);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.GetHistoricTempAsync().ConfigureAwait(false);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public async Task ShouldBeAbleToUpdateARangeState()
    {
        var warmTemp = Samples.temperaturesRange.FirstOrDefault();
        var expected = new TemperatureRange(warmTemp!.Id, warmTemp.State, 25, 40);

        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.UpdateRangeStateAsync(expected!.Id, expected.Start, expected.End)).ReturnsAsync(true);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.UpdateRangeStateAsync(expected!.Id, expected.Start, expected.End).ConfigureAwait(false);

        Assert.True(actual);
    }
}
