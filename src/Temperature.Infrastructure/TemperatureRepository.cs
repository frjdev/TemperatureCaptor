using System.Collections.Immutable;
using Temperature.Domain;

namespace Temperature.Infrastructure;
public class TemperatureRepository : ITemperatureRepository
{
    public Task<ImmutableList<Domain.Temperature?>> GetHistoricTempAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Temperature?> GetTemperatureAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateRangeStateAsync(int idstate, double start, double end)
    {
        throw new NotImplementedException();
    }
}
