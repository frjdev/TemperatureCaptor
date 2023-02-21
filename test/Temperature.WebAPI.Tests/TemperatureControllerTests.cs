using System.Net;
using Newtonsoft.Json;

namespace Temperature.WebAPI.Tests;
public class TemperatureControllerTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly TestWebApplicationFactory<Program> _Factory;
    private readonly HttpClient _HttpClient;
    private const string RequestBaseUri = "http://localhost/api/Temperature";

    public TemperatureControllerTests(TestWebApplicationFactory<Program> factory)
    {
        _Factory = factory;
        _HttpClient = factory.CreateClient();
    }

    [Fact]
    public async Task ShouldBeAbleToReturnATemperature()
    {
        var httpResponse = await _HttpClient.GetAsync(RequestBaseUri);

        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);


        var responseAsString = await httpResponse.Content.ReadAsStringAsync();
        Assert.NotNull(responseAsString);

        var actualValue = JsonConvert.DeserializeObject<TemperatureView>(responseAsString);

        Assert.NotNull(actualValue);
    }

}

