using System.Collections.Immutable;

namespace Temperature.Domain;

public class TemperatureService
{
    private readonly ITemperatureRepository _TemperatureRepository;

    public TemperatureService(ITemperatureRepository temperatureRepository)
    {
        _TemperatureRepository = temperatureRepository;
    }

    public async Task<double?> GetTemperatureAsync()
    {
        return await _TemperatureRepository.GetTemperatureAsync();
    }
    public async Task<ImmutableList<Temperature?>> GetHistoricTempAsync()
    {
        return await _TemperatureRepository.GetHistoricTempAsync();
    }
    public async Task<bool> UpdateRangeStateAsync(string state, double start, double end)
    {
        return await _TemperatureRepository.UpdateRangeStateAsync(state, start, end);
    }
    public async Task<string?> GetTempStateAsync(double temperature)
    {
        return await _TemperatureRepository.GetTempStateAsync(temperature);
    }
}
