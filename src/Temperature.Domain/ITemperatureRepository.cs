using System.Collections.Immutable;

namespace Temperature.Domain;
public interface ITemperatureRepository
{
    Task<Temperature?> GetTemperatureAsync();
    Task<ImmutableList<Temperature?>> GetHistoricTempAsync();
}