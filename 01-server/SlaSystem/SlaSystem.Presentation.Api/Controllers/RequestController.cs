using Microsoft.AspNetCore.Mvc;

namespace SlaSystem.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestController : ControllerBase
{
    private readonly ILogger<RequestController> _logger;

    public RequestController(ILogger<RequestController> logger)
    {
        _logger = logger;
    }
}
