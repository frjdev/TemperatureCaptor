using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Temperature.Infrastructure;
public record TemperatureDataRange
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string? State { get; set; }
    public double Start { get; set; }
    public double End { get; set; }
}
