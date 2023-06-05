
using SlaSystem.Presentation.Api.Utils;

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

    [HttpPost("Login", Name = "Login")]
    [ProducesResponseType(typeof(Result<User>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<User>>> Login([FromBody] LoginRequest loginRequest, 
        CancellationToken cancellationToken)
    {
        var command = new LoginCommand(UserName.Create(loginRequest.UserName), Password.Create(loginRequest.Password));
        var result = await Sender.Send(command, cancellationToken);
        var userDto = AutoMapper.MapUser(result.Value);
        return result.IsSuccess ? Ok(Result.Success(userDto)) : BadRequest(result.Error);
    }
    
    [HttpPost("Register", Name = "Register")]
    [ProducesResponseType(typeof(Result<User>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<User>>> Register([FromBody] RegisterRequest registerRequest, 
        CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(UserName.Create(registerRequest.UserName), 
            Password.Create(registerRequest.Password), Zone.Create(registerRequest.Zone), null, Role.Client);
        
        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Created("/auth/login", result): BadRequest(result.Error);
    }
}
