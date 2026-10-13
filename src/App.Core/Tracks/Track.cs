namespace App.Core.Tracks;

/// <summary>
/// A devotional track: a series of daily readings a user works through.
/// </summary>
public sealed record Track(Guid Id, string Title, string Description, int TotalDays);
