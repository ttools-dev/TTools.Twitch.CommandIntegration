using System.Dynamic;
using StatusGeneric;

namespace TTools.Twitch.CommandIntegration.Service.Models;

public readonly struct NotPlaying
{
    public readonly DateTime LastUpdated;

    private NotPlaying(DateTime lastUpdated)
    {
        LastUpdated = lastUpdated;
    }

    public static IStatus<NotPlaying> CreateInstance(DateTime lastUpdated)
    {
        // We don't really care about validation, but it's nice to keep it in line with the other models
        return new StatusHandler<NotPlaying>()
            .SetResult(new NotPlaying(lastUpdated));
    }
}
