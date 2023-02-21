using System.Collections.Immutable;

namespace Temperature.Domain;

public class TemperatureService : ITemperatureService
{
    private readonly ITemperatureRepository _TemperatureRepository;

    public TemperatureService(ITemperatureRepository temperatureRepository)
    {
        _TemperatureRepository = temperatureRepository;
    }
    public async Task<double?> GetTemperatureFromGeneratorAsync()
    {
        return await _TemperatureRepository.GetTemperatureFromGeneratorAsync();
    }
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
    public async Task<ImmutableList<Temperature?>> GetHistoricTempAsync()
    {
        return await _TemperatureRepository.GetHistoricTempAsync();
    }
    public async Task<bool> UpdateRangeStateAsync(string state, double start, double end)
    {
        return await _TemperatureRepository.UpdateRangeStateAsync(state, start, end);
    }
    public async Task<string?> GetTempStateAsync(double temp)
    {
        return await _TemperatureRepository.GetTempStateAsync(temp);
    }
    public async Task<Temperature?> CreateTemperatureAsync(double temperature, string state)
    {
        var temperatureDomain = await _TemperatureRepository.CreateTemperatureAsync(temperature, state);

        return temperatureDomain!;
    }
}
