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

    /// <summary>
    /// Get a temperature
    /// </summary>
    /// <returns>Result from the request</returns>
    [HttpGet]
    public async Task<IResult> GetTemperature()
    {
        var temp = await _TemperatureService.GetTemperatureAsync();

        if (temp == null)
        {
            return TypedResults.BadRequest();
        }
        return TypedResults.Ok(TemperatureView.FromDomain(temp));
    }
    /// <summary>
    /// Get a state of a temperature
    /// </summary>
    /// <param name="temperature"></param>
    /// <returns>Result from request</returns>
    [HttpGet("state/{temperature}")]
    public async Task<IResult> GetTemperatureState(double temperature)
    {
        var state = await _TemperatureService.GetTempStateAsync(temperature);
        if (state == null)
        {
            return TypedResults.BadRequest();
        }
        return TypedResults.Ok(state);
    }
    /// <summary>
    /// Get the last fifteen temperatures
    /// </summary>
    /// <returns>Result from request</returns>
    [HttpGet("Last15Temperatures")]
    public async Task<IResult> GetLast15Temperatures()
    {
        var state = await _TemperatureService.GetLast15TempAsync();
        if (state == null)
        {
            return TypedResults.BadRequest();
        }
        return TypedResults.Ok(state);
    }
    /// <summary>
    /// Update the range of a state
    /// </summary>
    /// <param name="state"></param>
    /// <param name="temperatureUpdateModel"></param>
    /// <returns>Result from request</returns>
    [HttpPut("{state}")]
    public async Task<IResult> UpdateState(string state, TemperatureUpdateModel temperatureUpdateModel)
    {
        var result = await _TemperatureService.UpdateRangeStateAsync(state, temperatureUpdateModel.Start, temperatureUpdateModel.End);
        return result == false ? TypedResults.NotFound() : TypedResults.NoContent();
    }
}
