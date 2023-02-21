using Microsoft.EntityFrameworkCore;
using Temperature.Domain;
using Temperature.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITemperatureRepository, TemperatureRepository>();
builder.Services.AddTransient<ITemperatureService, TemperatureService>();

var workingDirectory = Environment.CurrentDirectory;
var dataBaseDirectory = $@"{Directory.GetParent(workingDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName}\src\Temperature.Infrastructure";

var DbPath = Path.Join(workingDirectory, "Temperature.db");

builder.Services.AddDbContext<TemperatureContext>(options =>
{
    options.UseSqlite($"DataSource={DbPath}");
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
