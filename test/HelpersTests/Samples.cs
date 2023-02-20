namespace HelpersTests;
public class Samples
{
    public static readonly List<Temperature.Domain.Temperature?> temperatures = new()
    {
        new (1, 22, "WARM", DateTime.Now),
        new (2, -3, "COLD", DateTime.Now),
        new (3, 37, "HOT", DateTime.Now)
    };

    public static readonly List<Temperature.Domain.TemperatureRange?> temperaturesRange = new()
    {
        new (1,"WARM",22,40),
        new (2,"COLD",22,-60),
        new (3,"HOT",40,-60)
    };
}
