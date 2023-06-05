using Microsoft.AspNetCore.Mvc;

namespace SlaSystem.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlaController : ControllerBase
{
    private readonly ILogger<SlaController> _logger;

    public SlaController(ILogger<SlaController> logger)
    {
        _logger = logger;
    }
}
