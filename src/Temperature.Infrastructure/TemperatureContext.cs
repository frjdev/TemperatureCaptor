using HelpersTests;
using Microsoft.EntityFrameworkCore;
using Temperature.Domain;

namespace Temperature.Infrastructure;
public sealed class TemperatureContext : DbContext
{
    public TemperatureContext()
    {

    }
    public TemperatureContext(DbContextOptions<TemperatureContext> options)
        : base(options)
    {

    }
    public DbSet<TemperatureData> TemperatureSet { get; set; } = default!;
    public DbSet<TemperatureDataRange> TemperatureRangeSet { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TemperatureData>().HasData(Samples.Temperatures!.Select(TempFromDomain));

        modelBuilder.Entity<TemperatureDataRange>().HasData(Samples.TemperaturesRange!.Select(RangeFromDomain));
    }

    private static TemperatureData TempFromDomain(Domain.Temperature? temperature)
        => new TemperatureData()
        {
            Id = temperature!.Id,
            Temp = temperature!.Temp,
            State = temperature.State,
            Date = temperature.Date
        };
    private static TemperatureDataRange RangeFromDomain(TemperatureRange? temperature)
        => new TemperatureDataRange()
        {
            Id = temperature!.Id,
            State = temperature!.State,
            Start = temperature.Start,
            End = temperature.End
        };
}
