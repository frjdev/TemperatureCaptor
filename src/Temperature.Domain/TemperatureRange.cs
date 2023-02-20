namespace Temperature.Domain;
public record TemperatureRange
{
    public TemperatureRange(
        int id,
        string? state,
        double start,
        double end)
    {
        Id = id;
        State = state;
        Start = start;
        End = end;
    }

    public int Id { get; set; }
    public string? State { get; set; }
    public double Start { get; set; }
    public double End { get; set; }
}
