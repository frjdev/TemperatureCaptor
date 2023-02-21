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
        modelBuilder.Entity<TemperatureData>().HasData(Samples.Temperatures!);

        modelBuilder.Entity<TemperatureRange>().HasData(Samples.TemperaturesRange!);
    }
}
