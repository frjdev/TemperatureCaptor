namespace Temperature.Domain;
public record Temperature
{
    public Temperature(
         int id,
         decimal temp,
         string? state,
         DateTime date)
    {
        Id = id;
        Temp = temp;
        State = state;
        Date = date;
    }

    public int Id { get; set; }
    public decimal Temp { get; set; }
    public string? State { get; set; }
    public DateTime Date { get; set; }

}
