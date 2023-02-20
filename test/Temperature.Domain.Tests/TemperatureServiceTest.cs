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
}
