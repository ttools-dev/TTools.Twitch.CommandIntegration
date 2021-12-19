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
        return Ok("TODO");
    }
}
