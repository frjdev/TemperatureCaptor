namespace Temperature.WebAPI;

public record TemperatureView
{
    public TemperatureView(
        int id,
        double temp,
        string? state,
        DateTime date)
    {
        Id = id;
        Temp = temp;
        State = state;
        Date = date;
    }

    public int Id { get; }
    public double Temp { get; }
    public string? State { get; }
    public DateTime Date { get; }

    public static TemperatureView FromDomain(Domain.Temperature temperature)
        => new TemperatureView(temperature.Id, temperature.Temp, temperature.State, temperature.Date);
}
