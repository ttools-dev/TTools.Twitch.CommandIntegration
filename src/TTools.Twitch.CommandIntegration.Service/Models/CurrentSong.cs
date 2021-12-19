using StatusGeneric;

namespace TTools.Twitch.CommandIntegration.Service.Models;

public class CurrentSongModel
{
    public string Title { get; }
    public string Requester { get; }

    private CurrentSongModel(string title, string requester)
    {
        Title = title;
        Requester = requester;
    }

    /// <summary>
    /// Creates an instance of CurrentSong with validation
    /// </summary>
    /// <param name="title">The title of the current song</param>
    /// <param name="requester">The requester of the current song</param>
    /// <returns>A status containing a CurrentSong instance or validation errors</returns>
    public static IStatus<CurrentSongModel> CreateInstance(string title, string requester)
    {
        var status = new StatusHandler<CurrentSongModel>();

        if (string.IsNullOrWhiteSpace(title))
            status.AddError("Title cannot be empty");

        if (string.IsNullOrWhiteSpace(requester))
            status.AddError("Requester cannot be empty");

        return status.HasErrors ? status : status.SetResult(new CurrentSongModel(title, requester));
    }
}