using System.Collections.Immutable;

namespace Temperature.Domain;
public interface ITemperatureService
{
    Task<double?> GetTemperatureAsync();
    Task<string?> GetTempStateAsync(double temp);
    Task<ImmutableList<Temperature?>> GetHistoricTempAsync();
    Task<bool> UpdateRangeStateAsync(string state, double start, double end);
}
