using OneOf;
using TTools.Twitch.CommandIntegration.Service.Models;

namespace TTools.Twitch.CommandIntegration.Service.Interfaces;

/// <summary>
/// Actions around DJ-like services (pubby, plug.dj etc.)
/// </summary>
public interface IDjSongService
{
    /// <summary>
    /// Gets the currently playing song for the given room ID
    /// </summary>
    /// <param name="roomId">The DJ's room ID (path segment)</param>
    /// <returns>The current song, a not playing status or an unavailable reason</returns>
    Task<OneOf<CurrentSong, NotPlaying, NotFound, Unavailable>> GetCurrentSongForRoomAsync(string roomId);
}
