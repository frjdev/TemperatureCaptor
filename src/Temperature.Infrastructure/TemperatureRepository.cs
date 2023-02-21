using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
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

    public async Task<double?> GetTemperatureAsync()
    {
        return await Task.FromResult(_Captor.CaptorTemperature()).ConfigureAwait(false);
    }

    public async Task<string?> GetTempStateAsync(double temp)
    {
        var states = await GetStates().ConfigureAwait(false);

        var warm = states.FirstOrDefault(x => x.State!.ToUpper() == "WARM");
        var cold = states.FirstOrDefault(x => x.State!.ToUpper() == "COLD");
        var hot = states.FirstOrDefault(x => x.State!.ToUpper() == "HOT");

        if (warm!.Start < temp && warm.End > temp)
        {
            return "WARM";
        }

        if (cold!.Start >= temp)
        {
            return "COLD";
        }

        return "HOT";
    }

    public Task<bool> UpdateRangeStateAsync(int idstate, double start, double end)
    {
        throw new NotImplementedException();
    }
    private async Task<IEnumerable<TemperatureRange>> GetStates()
    {
        var states = await Task.FromResult(_Context.TemperatureRangeSet).ConfigureAwait(false);

        return (IEnumerable<TemperatureRange>)states;
    }
}
