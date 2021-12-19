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

    [HttpGet(Name = "GetDummyEndpoint")]
    public async Task<ActionResult> Get() => Ok();
}
