using StatusGeneric;

namespace TTools.Twitch.CommandIntegration.Service.Models;

public readonly struct Unavailable
{
    public readonly string Reason;
    public readonly DateTime LastUpdated;

    private Unavailable(string reason, DateTime lastUpdated)
    {
        Reason = reason;
        LastUpdated = lastUpdated;
    }

    /// <summary>
    /// Creates an instance of Unavailable with validation
    /// </summary>
    /// <param name="reason">The reason the service is unavailable</param>
    /// <param name="lastUpdated">The last time the status was updated</param>
    /// <returns>A status containing an Unavailable instance or validation errors</returns>
    public static IStatus<Unavailable> CreateInstance(string reason, DateTime lastUpdated)
    {
        // We don't really care about validation, but it's nice to keep it in line with the other models
        return new StatusHandler<Unavailable>()
            .SetResult(new Unavailable(reason, lastUpdated));
    }
}
