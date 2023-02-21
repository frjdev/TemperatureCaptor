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

    /// <summary>
    /// Get the last fifteen temperatures objects
    /// </summary>
    /// <returns>A immutable list of temperatures</returns>
    public Task<ImmutableList<Domain.Temperature?>> GetLast15TempAsync()
    {
        var temperaturesData = _Context.TemperatureSet!.OrderByDescending(x => x.Date).Take(15);

        var temperatures = temperaturesData.Select(x => TemperatureData.ToDomain(x)).ToImmutableList();

        return Task.FromResult(temperatures);
    }
    /// <summary>
    /// Get a temperature value
    /// </summary>
    /// <returns>A double value</returns>
    public async Task<double?> GetTemperatureFromGeneratorAsync()
    {
        return await Task.FromResult(_Captor.CaptorTemperature());
    }
    /// <summary>
    /// Get the state of a temperature value
    /// </summary>
    /// <param name="temp"></param>
    /// <returns>String state</returns>
    public async Task<string?> GetTempStateAsync(double temp)
    {
        var states = await GetStates();

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
    /// <summary>
    /// update the range of a state
    /// </summary>
    /// <param name="state"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns>true or false</returns>
    public async Task<bool> UpdateRangeStateAsync(string state, double start, double end)
    {
        var result = await UpdateRangeState(state, start, end);

        return !result ? false : await UpdateOthersStates(state);
    }
    /// <summary>
    /// Create a new temperature object
    /// </summary>
    /// <param name="temperature"></param>
    /// <param name="state"></param>
    /// <returns>A temperature </returns>
    public async Task<Domain.Temperature?> CreateTemperatureAsync(double temperature, string state)
    {
        var temperatureData = new TemperatureData()
        {
            Temp = temperature,
            State = state,
            Date = DateTime.Now
        };

        await _Context.TemperatureSet.AddAsync(temperatureData);
        var writtenState = await _Context.SaveChangesAsync();

        if (writtenState != 1)
        {
            return null;
        }

        return TemperatureData.ToDomain(temperatureData);
    }

    private async Task<bool> UpdateRangeState(string state, double start, double end)
    {
        var range = _Context.TemperatureRangeSet!.FirstOrDefault(x => x.State == state);

        if (range == null)
        {
            return false;
        }

        range.Start = start;
        range.End = end;

        _Context.TemperatureRangeSet!.Update(range);

        var writtenStateEntries = await _Context.SaveChangesAsync();

        return writtenStateEntries == 1;
    }
    private async Task<bool> UpdateOthersStates(string state)
    {
        var states = await GetStates();

        var warm = states.FirstOrDefault(x => x.State!.ToUpper() == "WARM");
        var cold = states.FirstOrDefault(x => x.State!.ToUpper() == "COLD");
        var hot = states.FirstOrDefault(x => x.State!.ToUpper() == "HOT");
        var result = false;

        switch (state.ToUpper())
        {
            case "HOT":
                result = await UpdateRangeState("WARM", warm!.Start, hot!.Start);
                break;
            case "COLD":
                result = await UpdateRangeState("WARM", cold!.Start, warm!.End);
                break;
            case "WARM":
                result = await UpdateRangeState("HOT", warm!.End, hot!.End);
                if (result == false)
                    return false;

                result = await UpdateRangeState("COLD", warm!.Start, cold!.End);
                break;
            default:
                return false;
        };

        return result;

    }
    private async Task<IEnumerable<TemperatureDataRange>> GetStates()
    {
        var states = await Task.FromResult(_Context.TemperatureRangeSet);

        return states;
    }
}
