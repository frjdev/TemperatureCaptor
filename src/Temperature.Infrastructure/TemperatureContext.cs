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
        modelBuilder.Entity<TemperatureData>().HasData(new TemperatureData { Id = 1, State = "COLD", Temp = 4, Date = DateTime.Now });
        modelBuilder.Entity<TemperatureData>().HasData(new TemperatureData { Id = 2, State = "HOT", Temp = 41, Date = DateTime.Now });

        modelBuilder.Entity<TemperatureRange>().HasData(new TemperatureDataRange { Id = 1, State = "HOT", Start = 40, End = 60 });
        modelBuilder.Entity<TemperatureRange>().HasData(new TemperatureDataRange { Id = 2, State = "COLD", Start = 22, End = -50 });
        modelBuilder.Entity<TemperatureRange>().HasData(new TemperatureDataRange { Id = 3, State = "WARM", Start = 22, End = 40 });
    }
}
