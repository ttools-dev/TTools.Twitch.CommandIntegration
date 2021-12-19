using TTools.Twitch.CommandIntegration.Service.Interfaces;
using TTools.Twitch.CommandIntegration.Service.Models;

namespace TTools.Twitch.CommandIntegration.Service.Services;

public class PubbySongService : IDjSongService
{
    public Task<CurrentSong> GetCurrentSongForRoomAsync(string roomId)
    {
        return Task.FromResult(CurrentSong.CreateInstance("No title", "requester").Result);
    }
}
