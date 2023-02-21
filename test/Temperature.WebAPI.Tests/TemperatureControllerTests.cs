using System.Collections.Immutable;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Temperature.WebAPI.Tests;
public class TemperatureControllerTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly HttpClient _HttpClient;
    private const string RequestBaseUri = "http://localhost/api/Temperature";

    public TemperatureControllerTests(TestWebApplicationFactory<Program> factory)
    {
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

    [Fact]
    public async Task ShouldBeAbleToReturnTheLast15Temperatures()
    {
        var httpResponse = await _HttpClient.GetAsync(@$"{RequestBaseUri}\Last15Temperatures");

        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

        var responseAsString = await httpResponse.Content.ReadAsStringAsync();
        Assert.NotNull(responseAsString);

        var actualValue = JsonConvert.DeserializeObject<ImmutableList<TemperatureView>>(responseAsString);

        Assert.NotNull(actualValue);
        Assert.Equal(15, actualValue.Count);
    }

    [Fact]
    public async Task ShouldBeAbleToUpdateTheRangeOfAState()
    {
        var state = "HOT";
        var stateRange = new TemperatureUpdateModel() { Start = 35, End = 60 };

        var content = JsonConvert.SerializeObject(stateRange);
        var requestBody = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _HttpClient.PutAsync($"{RequestBaseUri}/{state}", requestBody);
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

    }

}

