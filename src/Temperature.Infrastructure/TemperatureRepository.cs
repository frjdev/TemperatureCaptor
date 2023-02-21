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
        var temperaturesData = _Context.TemperatureSet!.OrderByDescending(x => x.Date == DateTime.Now).Take(15);

        var temperatures = temperaturesData.Select(x => TemperatureData.ToDomain(x)).ToImmutableList();

        return Task.FromResult(temperatures);
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

    public async Task<bool> UpdateRangeStateAsync(int idstate, double start, double end)
    {
        var range = _Context.TemperatureRangeSet!.FirstOrDefault(x => x.Id == idstate);

        if (range == null)
            return false;

        range.Start = start;
        range.End = end;

        _Context.TemperatureRangeSet!.Update(range);

        var writtenStateEntries = await _Context.SaveChangesAsync().ConfigureAwait(false);

        return writtenStateEntries == 1;
    }
    private async Task<IEnumerable<TemperatureRange>> GetStates()
    {
        var states = await Task.FromResult(_Context.TemperatureRangeSet).ConfigureAwait(false);

        return (IEnumerable<TemperatureRange>)states;
    }
}
