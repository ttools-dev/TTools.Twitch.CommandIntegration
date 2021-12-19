using OneOf;
using TTools.Twitch.CommandIntegration.Service.Interfaces;
using TTools.Twitch.CommandIntegration.Service.Models;

namespace TTools.Twitch.CommandIntegration.Service.Services;

public class PubbySongService : IDjSongService
{
    public async Task<OneOf<CurrentSong, NotPlaying, Unavailable>> GetCurrentSongForRoomAsync(string roomId)
    {
        return CurrentSong.CreateInstance("No title", "requester", DateTime.Now).Result;
    }
}
