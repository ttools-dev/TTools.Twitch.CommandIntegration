using Microsoft.AspNetCore.Mvc;

namespace TTools.Twitch.CommandIntegration.Api.Controllers;

[ApiController, Route("[controller]")]
public class PubbyController : ControllerBase
{
    private readonly ILogger<PubbyController> _logger;

    public PubbyController(ILogger<PubbyController> logger)
    {
        _logger = logger;
    }

    [HttpGet("current_song/{roomId}")]
    public async Task<ActionResult> GetCurrentSong(string roomId)
    {
        _logger.LogInformation("Getting current song for room ID {RoomId}", roomId);
        return Ok("TODO");
    }
}
