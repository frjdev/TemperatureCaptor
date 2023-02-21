namespace Temperature.Infrastructure;
public record TemperatureDataRange
{
    public int Id { get; set; }
    public string? State { get; set; }
    public double Start { get; set; }
    public double End { get; set; }
}
