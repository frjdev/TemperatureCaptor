using System.Collections.Immutable;
using Temperature.Domain;

namespace Temperature.Infrastructure;
public class TemperatureRepository : ITemperatureRepository
{
    private readonly ITemperatureCaptor _Captor;
    private readonly TemperatureContext _Context;

    public TemperatureRepository(TemperatureContext context, ITemperatureCaptor captor)
    {
        _Captor = captor;
        _Context = context;
    }
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
