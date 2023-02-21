using System.Collections.Immutable;
using HelpersTests;
using Moq;

namespace Temperature.Domain.Tests;

public class TemperatureServiceTest
{
    [Fact]
    public async Task ShouldBeAbleToReturnATemperature()
    {
        double? expected = Samples.temperatures.FirstOrDefault()!.Temp;

        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.GetTemperatureAsync()).Returns(Task.FromResult(expected));

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
        mockTemperatureRepo.Setup(x => x.UpdateRangeStateAsync(expected.State!, expected.Start, expected.End)).ReturnsAsync(true);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.UpdateRangeStateAsync(expected.State!, expected.Start, expected.End).ConfigureAwait(false);

        Assert.True(actual);
    }

    [Fact]
    public async Task ShouldBeAbleToGetTheStateOfATemperature()
    {
        var warmTemp = 25;
        var expected = "WARM";

        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.GetTempStateAsync(warmTemp)).ReturnsAsync(expected);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.GetTempStateAsync(warmTemp).ConfigureAwait(false);

        Assert.Equal(expected, actual);
    }

}
