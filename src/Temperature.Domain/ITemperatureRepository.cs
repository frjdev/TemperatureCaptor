using System.Collections.Immutable;

namespace Temperature.Domain;
public interface ITemperatureRepository
{
    Task<double?> GetTemperatureAsync();
    Task<ImmutableList<Temperature?>> GetHistoricTempAsync();
    Task<bool> UpdateRangeStateAsync(string state, double start, double end);
    Task<string?> GetTempStateAsync(double temp);
}
