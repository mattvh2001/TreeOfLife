namespace App.Core.Tracks;

/// <summary>
/// Business rules for tracks. Endpoints call this; this calls the repository.
/// </summary>
public sealed class TrackService(ITrackRepository repository)
{
    public async Task<IReadOnlyList<Track>> GetTracksAsync(CancellationToken cancellationToken = default)
    {
        var tracks = await repository.GetAllAsync(cancellationToken);
        return tracks.OrderBy(t => t.Title).ToList();
    }

    public Task<Track?> GetTrackAsync(Guid id, CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, cancellationToken);
}
