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

}
