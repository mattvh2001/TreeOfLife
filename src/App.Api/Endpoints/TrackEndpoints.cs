using App.Api.Contracts;
using App.Core.Tracks;

namespace App.Api.Endpoints;

public static class TrackEndpoints
{
    public static IEndpointRouteBuilder MapTrackEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/tracks").WithTags("Tracks");

        group.MapGet("/", GetTracks).WithName("GetTracks");
        group.MapGet("/{id:guid}", GetTrack).WithName("GetTrack");

        return app;
    }

    private static async Task<IResult> GetTracks(TrackService trackService, CancellationToken cancellationToken)
    {
        var tracks = await trackService.GetTracksAsync(cancellationToken);
        return Results.Ok(tracks.Select(TrackResponse.FromTrack));
    }

    private static async Task<IResult> GetTrack(Guid id, TrackService trackService, CancellationToken cancellationToken)
    {
        var track = await trackService.GetTrackAsync(id, cancellationToken);
        return track is null ? Results.NotFound() : Results.Ok(TrackResponse.FromTrack(track));
    }
}
