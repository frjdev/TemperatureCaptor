namespace Temperature.Domain;
public interface ITemperatureRepository
{
    Task<decimal> GetTemperatureAsync();
}
