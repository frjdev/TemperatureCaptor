using System.Collections.Immutable;

namespace Temperature.Domain;
public interface ITemperatureService
{
    Task<Temperature?> GetTemperatureAsync();
    Task<double?> GetTemperatureFromGeneratorAsync();
    Task<string?> GetTempStateAsync(double temp);
    Task<ImmutableList<Temperature?>> GetLast15TempAsync();
    Task<bool> UpdateRangeStateAsync(string state, double start, double end);
    Task<Temperature?> CreateTemperatureAsync(double temperature, string state);
}
