using Microsoft.EntityFrameworkCore;
using Temperature.Domain;
using Temperature.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITemperatureRepository, TemperatureRepository>();
builder.Services.AddTransient<ITemperatureService, TemperatureService>();
builder.Services.AddTransient<ITemperatureCaptor, TemperatureCaptorGenerator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var workingDirectory = Environment.CurrentDirectory;
var dataBaseDirectory = $@"{Directory.GetParent(workingDirectory)!.FullName}\Temperature.Infrastructure";

var DbPath = Path.Join(workingDirectory, "Temperature.db");

builder.Services.AddDbContext<TemperatureContext>(options =>
{
    options.UseSqlite($"DataSource={DbPath}");
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;

    });
}
app.MapControllers();

app.Run();
