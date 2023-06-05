using MediatR;
using SlaSystem.Application.Authentication.Commands;
using SlaSystem.Presentation.Api.Abstractions;

namespace SlaSystem.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ApiController
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger, ISender sender) : base(sender)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<Result<User>>> Login([FromBody] LoginRequest loginRequest, 
        CancellationToken cancellationToken)
    {
        var command = new LoginCommand(UserName.Create(loginRequest.UserName), Password.Create(loginRequest.Password));
        var result = await Sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
}
