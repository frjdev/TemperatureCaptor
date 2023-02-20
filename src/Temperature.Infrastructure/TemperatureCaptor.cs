namespace Temperature.Infrastructure;
public static class TemperatureCaptor
{
    public static double GenerateTemp()
    {
        var rng = new Random();
        var temparture = rng.Next(-60, 60);

        return temparture;
    }
}
