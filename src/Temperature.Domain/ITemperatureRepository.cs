using System.Collections.Immutable;

namespace Temperature.Domain;
public interface ITemperatureRepository
{
    Task<double?> GetTemperatureFromGeneratorAsync();
    Task<ImmutableList<Temperature?>> GetLast15TempAsync();
    Task<bool> UpdateRangeStateAsync(string state, double start, double end);
    Task<string?> GetTempStateAsync(double temp);
    Task<Temperature?> CreateTemperatureAsync(double temperature, string state);
}
