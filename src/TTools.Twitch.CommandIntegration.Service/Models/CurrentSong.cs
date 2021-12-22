using StatusGeneric;

namespace TTools.Twitch.CommandIntegration.Service.Models;

public readonly struct CurrentSong
{
    public readonly string Title;
    public readonly string Requester;
    public readonly string MediaUrl;
    public readonly DateTime LastUpdated;

    private CurrentSong(string title, string requester, string mediaUrl, DateTime lastUpdated)
    {
        Title = title;
        Requester = requester;
        LastUpdated = lastUpdated;
        MediaUrl = mediaUrl;
    }

    /// <summary>
    /// Creates an instance of CurrentSong with validation
    /// </summary>
    /// <param name="title">The title of the current song</param>
    /// <param name="requester">The requester of the current song</param>
    /// <param name="mediaUrl">The URL of the currently playing media</param>
    /// <param name="lastUpdated">The last time the current song was updated</param>
    /// <returns>A status containing a CurrentSong instance or validation errors</returns>
    public static IStatus<CurrentSong> CreateInstance(string title, string requester,
        string mediaUrl, DateTime lastUpdated)
    {
        var status = new StatusHandler<CurrentSong>();

        if (string.IsNullOrWhiteSpace(title))
            status.AddError("Title cannot be empty", nameof(title));

        if (string.IsNullOrWhiteSpace(requester))
            status.AddError("Requester cannot be empty", nameof(requester));

        if (string.IsNullOrWhiteSpace(mediaUrl))
            status.AddError("Media URL cannot be empty", nameof(requester));

        return status.HasErrors ? status : status.SetResult(new CurrentSong(title, requester, mediaUrl, lastUpdated));
    }
}
