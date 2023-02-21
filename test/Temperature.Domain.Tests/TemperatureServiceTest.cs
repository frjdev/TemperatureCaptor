using System.Collections.Immutable;
using Helpers;
using Moq;

namespace Temperature.Domain.Tests;

public class TemperatureServiceTest
{
    [Fact]
    public async Task ShouldBeAbleToReturnATemperatureFromGenerator()
    {
        double? expected = Samples.Temperatures.FirstOrDefault()!.Temp;

        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.GetTemperatureFromGeneratorAsync()).Returns(Task.FromResult(expected));

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.GetTemperatureFromGeneratorAsync();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task ShouldBeAbleToReturnTheHisotricsOfLast15Temperature()
    {
        var expected = Samples.Temperatures.ToImmutableList();

        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.GetHistoricTempAsync())!.ReturnsAsync(expected);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.GetHistoricTempAsync();

        Assert.Equal(expected, actual);
    }
    [Fact]
    public async Task ShouldBeAbleToUpdateARangeState()
    {
        var warmTemp = Samples.TemperaturesRange.FirstOrDefault();
        var expected = new TemperatureRange(warmTemp!.Id, warmTemp.State, 25, 40);

        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.UpdateRangeStateAsync(expected.State!, expected.Start, expected.End)).ReturnsAsync(true);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.UpdateRangeStateAsync(expected.State!, expected.Start, expected.End);

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
        var actual = await temp.GetTempStateAsync(warmTemp);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task ShouldBeAbleToCreateATemperature()
    {
        var Temp = 25;
        var state = "WARM";
        var expected = new Temperature(int.MaxValue, Temp, state, DateTime.Now);

        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.CreateTemperatureAsync(Temp, state)).ReturnsAsync(expected);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.CreateTemperatureAsync(Temp, state);

        Assert.Equal(expected, actual);
    }

}
