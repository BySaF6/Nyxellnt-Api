using Microsoft.AspNetCore.Mvc;

namespace Nyxellnt_API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<EventoController> _logger;

    public EventoController(ILogger<EventoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "getEvento")]
    public Task<ActionResult<EventoEntity>> Get()
    {
        return Ok();
    }
}