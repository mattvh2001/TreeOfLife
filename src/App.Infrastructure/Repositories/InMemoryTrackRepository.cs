using App.Core.Tracks;

namespace App.Infrastructure.Repositories;

/// <summary>
/// Temporary in-memory store so the API works before a database is chosen.
/// Replace with an EF Core implementation of <see cref="ITrackRepository"/> later.
/// </summary>
public sealed class InMemoryTrackRepository : ITrackRepository
{
    private static readonly IReadOnlyList<Track> Tracks =
    [
        new(Guid.Parse("8f1c2a6e-3b4d-4c5e-9f60-1a2b3c4d5e01"), "Psalms of Praise", "Thirty days through the Psalms.", 30),
        new(Guid.Parse("8f1c2a6e-3b4d-4c5e-9f60-1a2b3c4d5e02"), "Gospel of John", "A three-week walk through John.", 21),
    ];

    public Task<IReadOnlyList<Track>> GetAllAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(Tracks);

    public Task<Track?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        Task.FromResult(Tracks.FirstOrDefault(t => t.Id == id));
}
