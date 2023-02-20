namespace Temperature.Infrastructure;
public class TemperatureCaptorGenerator : ITemperatureCaptor
{
    public double CaptorTemperature()
    {
        var rng = new Random();
        var temparture = rng.Next(-60, 60);

        return temparture;
    }
}
