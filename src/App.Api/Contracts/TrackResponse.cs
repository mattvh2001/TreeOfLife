using App.Core.Tracks;

namespace App.Api.Contracts;

/// <summary>
/// The shape of a track as the frontend sees it.
/// </summary>
public sealed record TrackResponse(Guid Id, string Title, string Description, int TotalDays)
{
    public static TrackResponse FromTrack(Track track) =>
        new(track.Id, track.Title, track.Description, track.TotalDays);
}
