
namespace HelpersTests;
public class Samples
{
    public static readonly List<Temperature.Domain.Temperature?> Temperatures = new ()
    {
        new (1, 22, "WARM", DateTime.Now),
        new (2, -3, "COLD", DateTime.Now),
        new (3, 37, "HOT", DateTime.Now),
        new (4, 39, "HOT",  DateTime.Now ),
        new (5, 37, "HOT",  DateTime.Now ),
        new (6, 41, "HOT",  DateTime.Now ),
        new (7, 41, "HOT",  DateTime.Now ),
        new (8, 40, "HOT",  DateTime.Now ),
        new (9, 32, "HOT",  DateTime.Now ),
        new (10, 34, "HOT",  DateTime.Now ),
        new (11, 25, "WARM",  DateTime.Now ),
        new (12, 26, "WARM",  DateTime.Now ),
        new (13, 20, "COLD",  DateTime.Now ),
        new (14, 16, "COLD",  DateTime.Now ),
        new (15, 14, "COLD",  DateTime.Now ),
        new (16, -3, "COLD",  DateTime.Now ),
        new (17, 30, "HOT",  DateTime.Now ),
        new (18, 28, "WARM",  DateTime.Now ),
        new (19, 26, "WARM",  DateTime.Now ),
        new (20, -3, "COLD",  DateTime.Now ),
    };

    public static readonly List<Temperature.Domain.TemperatureRange?> TemperaturesRange = new()
    {
        new(1, "WARM", 22, 40),
        new(2, "COLD", 22, -60),
        new(3, "HOT", 40, -60)
    };
}
