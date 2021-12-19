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

        _logger.LogInformation("Room ID {RoomId} is playing {SongTitle} requested by {Requester}",
            roomId, response.Title, response.Requester);

        return Ok($"Now playing: \"{response.Title}\" requested by \"{response.Requester}\"");
    }
}
