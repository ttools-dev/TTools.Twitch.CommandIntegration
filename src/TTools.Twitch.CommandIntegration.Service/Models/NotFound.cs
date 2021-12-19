using StatusGeneric;

namespace TTools.Twitch.CommandIntegration.Service.Models;

public readonly struct NotFound
{
    public readonly DateTime LastUpdated;

    private NotFound(DateTime lastUpdated)
    {
        LastUpdated = lastUpdated;
    }

    /// <summary>
    /// Creates an instance of NotFound with validation
    /// </summary>
    /// <param name="lastUpdated">The last time the status was updated</param>
    /// <returns>A status containing an NotFound instance or validation errors</returns>
    public static IStatus<NotFound> CreateInstance(DateTime lastUpdated)
    {
        // We don't really care about validation, but it's nice to keep it in line with the other models
        return new StatusHandler<NotFound>()
            .SetResult(new NotFound(lastUpdated));
    }
}
