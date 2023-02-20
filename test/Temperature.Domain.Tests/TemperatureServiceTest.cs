using System.Collections.Immutable;
using Moq;

namespace Temperature.Domain.Tests;

public class TemperatureServiceTest
{
    [Fact]
    public async Task ShouldBeAbleToReturnATemperature()
    {
        var expected = new Temperature(1, 22, "WARM", DateTime.Now);
        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.GetTemperatureAsync()).ReturnsAsync(expected);

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.GetTemperatureAsync().ConfigureAwait(false);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task ShouldBeAbleToReturnTheHisotricsOfLast15Temperature()
    {
        var expected = new List<Temperature>();


        var mockTemperatureRepo = new Mock<ITemperatureRepository>();
        mockTemperatureRepo.Setup(x => x.GetHistoricTempAsync())!.ReturnsAsync(expected.ToImmutableList());

        var temp = new TemperatureService(mockTemperatureRepo.Object);
        var actual = await temp.GetHistoricTempAsync().ConfigureAwait(false);

        Assert.Equal(expected, actual);
    }
}
