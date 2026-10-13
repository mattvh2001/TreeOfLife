namespace App.Core.Tracks;

/// <summary>
/// Storage for tracks. Core defines the contract; App.Infrastructure implements it.
/// </summary>
public interface ITrackRepository
{
    Task<IReadOnlyList<Track>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Track?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
