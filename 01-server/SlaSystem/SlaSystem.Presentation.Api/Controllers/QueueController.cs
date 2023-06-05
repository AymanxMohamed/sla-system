using Microsoft.AspNetCore.Mvc;

namespace SlaSystem.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QueueController : ControllerBase
{
    private readonly ILogger<QueueController> _logger;

    public QueueController(ILogger<QueueController> logger)
    {
        _logger = logger;
    }
}
