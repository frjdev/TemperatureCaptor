namespace Temperature.Domain.Tests;

public class TemperatureServiceTest
{
    [Theory]
    [InlineData(2)]
    public async Task ShouldBeAbleToReturnATemperature(decimal expected)
    {
        var temp = new TemperatureService();
        var actual = await temp.GetTemperatureAsync().ConfigureAwait(false);

        Assert.Equal(expected, actual);
    }
}
