using App.Core.Tracks;

namespace App.Tests.Tracks;

public class TrackServiceTests
{
    [Fact]
    public async Task GetTracksAsync_ReturnsTracksOrderedByTitle()
    {
        var repository = new FakeTrackRepository(
            new Track(Guid.NewGuid(), "Psalms", "", 30),
            new Track(Guid.NewGuid(), "Genesis", "", 50));
        var service = new TrackService(repository);

        var tracks = await service.GetTracksAsync();

        Assert.Equal(["Genesis", "Psalms"], tracks.Select(t => t.Title));
    }

    private sealed class FakeTrackRepository(params Track[] tracks) : ITrackRepository
    {
        public Task<IReadOnlyList<Track>> GetAllAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<Track>>(tracks);

        public Task<Track?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            Task.FromResult(tracks.FirstOrDefault(t => t.Id == id));
    }
}
