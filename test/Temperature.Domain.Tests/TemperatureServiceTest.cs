namespace Temperature.Domain.Tests;

public class TemperatureServiceTest
{
    [Theory]
    [InlineData(2)]
    public async Task ShouldBeAbleToReturnATemperature(decimal expected)
    {
        var temp = new TemperatureService();
        var actual = temp.GetTempAsync();

        Assert.Equal(expected, actual);
    }
}
