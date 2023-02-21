using Microsoft.AspNetCore.Mvc;
using Temperature.Domain;

namespace Temperature.WebAPI;
[Route("api/[controller]")]
[ApiController]
public class TemperatureController : ControllerBase
{
    private readonly ITemperatureService _TemperatureService;

    public TemperatureController(ITemperatureService temperatureService)
    {
        _TemperatureService = temperatureService;
    }

    [HttpGet]
    public async Task<IResult> GetTemperature()
    {
        var temp = await _TemperatureService.GetTemperatureAsync();

        if (temp == null)
        {
            return TypedResults.BadRequest();
        }
        return TypedResults.Ok(temp);
    }
    [HttpGet("{temperature}")]
    public async Task<IResult> GetTemperature(double temperature)
    {
        var state = await _TemperatureService.GetTempStateAsync(temperature);
        if (state == null)
        {
            return TypedResults.BadRequest();
        }
        return TypedResults.Ok(state);
    }
    [HttpGet("Last15Temperatures")]
    public async Task<IResult> GetLast15Temperatures()
    {
        var state = await _TemperatureService.GetHistoricTempAsync();
        if (state == null)
        {
            return TypedResults.BadRequest();
        }
        return TypedResults.Ok(state);
    }
}
