using System.Collections.Immutable;

namespace Temperature.Domain;
public interface ITemperatureRepository
{
    Task<Temperature?> GetTemperatureAsync();
    Task<ImmutableList<Temperature?>> GetHistoricTempAsync();
    Task<bool> UpdateRangeStateAsync(int idstate, double start, double end);
    Task<string?> GetTempStateAsync(double temp);
}
