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
}
