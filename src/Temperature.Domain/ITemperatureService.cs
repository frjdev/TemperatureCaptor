namespace Temperature.Domain;
public interface ITemperatureService
{
    Task<double?> GetTemperatureAsync();
}
