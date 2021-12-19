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
    public async Task<ActionResult> GetCurrentSong(string roomId)
    {
        _logger.LogInformation("Getting current song for room ID {RoomId}", roomId);
        return Ok("TODO");
    }
}
