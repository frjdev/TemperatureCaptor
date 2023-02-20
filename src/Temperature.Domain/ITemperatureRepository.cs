namespace Temperature.Domain;
public interface ITemperatureRepository
{
    Task<Temperature?> GetTemperatureAsync();
}
