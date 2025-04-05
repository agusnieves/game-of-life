using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using GameOfLife.Api;
using static GameOfLife.Tests.Data.TestBoards;
using GameOfLife.Api.Models;


namespace IntegrationTests;

public class GameOfLifeApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public GameOfLifeApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    } 
    
    [Fact]
    public async Task PostBoard_ThenGetNext_ShouldReturn200()
    {
        var board = new { state = FullAliveBoard };

        var postResponse = await _client.PostAsJsonAsync("/board", board);
        postResponse.EnsureSuccessStatusCode();

        var responseBody = await postResponse.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(responseBody);
        var id = json.RootElement.GetProperty("id").GetGuid();

        Assert.NotEqual(Guid.Empty, id);

        var getResponse = await _client.GetAsync($"/board/{id}/next");
        getResponse.EnsureSuccessStatusCode();

    }

    [Fact]
    public async Task GetFinal_ShouldReturn200()
    {
        var board = new { state = LoopVertical };

        var postResponse = await _client.PostAsJsonAsync("/board", board);
        postResponse.EnsureSuccessStatusCode();

        var responseBody = await postResponse.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(responseBody);
        var id = json.RootElement.GetProperty("id").GetGuid();

        Assert.NotEqual(Guid.Empty, id);

        var getResponse = await _client.GetAsync($"/board/{id}/final");
        getResponse.EnsureSuccessStatusCode();

    }
}