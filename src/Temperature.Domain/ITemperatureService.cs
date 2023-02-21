namespace Temperature.Domain;
public interface ITemperatureService
{
    Task<double?> GetTemperatureAsync();
    Task<string?> GetTempStateAsync(double temp);
}
