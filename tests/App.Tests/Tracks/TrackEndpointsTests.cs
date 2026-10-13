using System.Net;
using System.Net.Http.Json;

using App.Api.Contracts;

using Microsoft.AspNetCore.Mvc.Testing;

namespace App.Tests.Tracks;

public class TrackEndpointsTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetTracks_ReturnsTracks()
    {
        var tracks = await _client.GetFromJsonAsync<List<TrackResponse>>("/api/tracks");

        Assert.NotNull(tracks);
        Assert.NotEmpty(tracks);
    }

    [Fact]
    public async Task GetTrack_UnknownId_ReturnsNotFound()
    {
        var response = await _client.GetAsync($"/api/tracks/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
