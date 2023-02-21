using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Temperature.Infrastructure;
public record TemperatureData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public double Temp { get; set; }
    public string? State { get; set; }
    public DateTime Date { get; set; }

    public static Domain.Temperature? ToDomain(TemperatureData tempData)
        => new Domain.Temperature(tempData.Id, tempData.Temp, tempData.State, tempData.Date);
}
