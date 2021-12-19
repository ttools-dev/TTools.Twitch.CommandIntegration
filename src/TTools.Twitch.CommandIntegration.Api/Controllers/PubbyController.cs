using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TTools.Twitch.CommandIntegration.Service.Interfaces;

namespace TTools.Twitch.CommandIntegration.Api.Controllers;

[ApiController, Route("[controller]")]
public class PubbyController : ControllerBase
{
    private readonly ILogger<PubbyController> _logger;
    private readonly IDjSongService _songService;

    public PubbyController(ILogger<PubbyController> logger, IDjSongService songService)
    {
        _logger = logger;
        _songService = songService;
    }

    [HttpGet("current_song/{roomId}")]
    [Produces(MediaTypeNames.Text.Plain), Consumes(MediaTypeNames.Text.Plain)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetCurrentSong(string roomId)
    {
        _logger.LogInformation("Getting current song for room ID {RoomId}", roomId);

        // TODO: return OneOf of current song, not playing, or unavailable
        var response = await _songService.GetCurrentSongForRoomAsync(roomId);
        return response.Match<ActionResult>(
            song =>
            {
                _logger.LogInformation(
                    "Room ID {RoomId} is playing {SongTitle} requested by {Requester} updated at {UpdatedAt}",
                    roomId, song.Title, song.Requester, song.LastUpdated);
                return Ok($"Now playing: \"{song.Title}\" requested by \"{song.Requester}\"");
            },
            notPlaying =>
            {
                _logger.LogInformation("Room ID {RoomId} is not playing anything, updated at {UpdatedAt}",
                    roomId, notPlaying.LastUpdated);
                return Ok("No song us currently playing");
            },
            notFound =>
            {
                _logger.LogInformation("Room ID {RoomId} could not be found, updated at {UpdatedAt}",
                    roomId, notFound.LastUpdated);
                return NotFound($"Room \"{roomId}\" was not found");
            },
            unavailable =>
            {
                _logger.LogWarning(
                    "Room ID {RoomId} is unavailable because \"{Reason}\", updated at {UpdatedAt}",
                    roomId, unavailable.Reason, unavailable.LastUpdated);
                return Ok("Unable to get the current song");
            });
    }
}
