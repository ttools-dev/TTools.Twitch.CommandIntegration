using OneOf;
using TTools.Twitch.CommandIntegration.Service.Interfaces;
using TTools.Twitch.CommandIntegration.Service.Models;

namespace TTools.Twitch.CommandIntegration.Service.Services;

public class PubbySongService : IDjSongService
{
    public async Task<OneOf<CurrentSong, NotPlaying, NotFound, Unavailable>> GetCurrentSongForRoomAsync(string roomId)
    {
        return roomId switch
        {
            "found" => CurrentSong.CreateInstance("Darude Sandstorm", "jammehcow", "", DateTime.Now).Result,
            "no-song" => NotPlaying.CreateInstance(DateTime.Now).Result,
            "unavailable" => Unavailable.CreateInstance("Service timed out", DateTime.Now).Result,
            _ => NotFound.CreateInstance(DateTime.Now).Result
        };
    }
}
