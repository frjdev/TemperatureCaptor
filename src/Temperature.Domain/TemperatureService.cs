using System.Collections.Immutable;

namespace Temperature.Domain;

public class TemperatureService
{
    public readonly ITemperatureRepository _temperatureRepository;

    public TemperatureService(ITemperatureRepository temperatureRepository)
    {
        _temperatureRepository = temperatureRepository;
    }

    public async Task<Temperature?> GetTemperatureAsync()
    {
        return await _temperatureRepository.GetTemperatureAsync().ConfigureAwait(false);
    }
    public async Task<ImmutableList<Temperature?>> GetHistoricTempAsync()
    {
        return await _temperatureRepository.GetHistoricTempAsync().ConfigureAwait(false);
    }
}
