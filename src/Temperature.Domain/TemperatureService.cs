using System.Collections.Immutable;

namespace Temperature.Domain;

public class TemperatureService : ITemperatureService
{
    private readonly ITemperatureRepository _TemperatureRepository;

    public TemperatureService(ITemperatureRepository temperatureRepository)
    {
        _TemperatureRepository = temperatureRepository;
    }
    /// <summary>
    /// Get a temperature value 
    /// </summary>
    /// <returns>a double</returns>
    public async Task<double?> GetTemperatureFromGeneratorAsync()
    {
        return await _TemperatureRepository.GetTemperatureFromGeneratorAsync();
    }
    /// <summary>
    /// Get a temperature object 
    /// </summary>
    /// <returns>a Temperature</returns>
    public async Task<Temperature?> GetTemperatureAsync()
    {
        var temp = await _TemperatureRepository.GetTemperatureFromGeneratorAsync();
        if (temp == null)
        {
            return null;
        }
        var state = await _TemperatureRepository.GetTempStateAsync((double)temp);
        var temperature = await _TemperatureRepository.CreateTemperatureAsync((double)temp, state!);

        return temperature!;

    }
    /// <summary>
    /// Get the last fifteen temperatures
    /// </summary>
    /// <returns>An Immutable list of temperatures</returns>
    public async Task<ImmutableList<Temperature?>> GetLast15TempAsync()
    {
        return await _TemperatureRepository.GetLast15TempAsync();
    }
    /// <summary>
    /// Update the range of a temperature
    /// </summary>
    /// <param name="state"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns>True or false</returns>
    public async Task<bool> UpdateRangeStateAsync(string state, double start, double end)
    {
        return await _TemperatureRepository.UpdateRangeStateAsync(state, start, end);
    }
    /// <summary>
    /// Get the state of a temperature
    /// </summary>
    /// <param name="temp"></param>
    /// <returns>a string value ("WARM", "COLD", "HOT") </returns>
    public async Task<string?> GetTempStateAsync(double temp)
    {
        return await _TemperatureRepository.GetTempStateAsync(temp);
    }
    /// <summary>
    /// Create a new temperature object
    /// using GetTemperatureFromGeneratorAsync and GetTempStateAsync
    /// </summary>
    /// <param name="temperature"></param>
    /// <param name="state"></param>
    /// <returns>A temperature </returns>
    public async Task<Temperature?> CreateTemperatureAsync(double temperature, string state)
    {
        var temperatureDomain = await _TemperatureRepository.CreateTemperatureAsync(temperature, state);

        return temperatureDomain!;
    }
}
