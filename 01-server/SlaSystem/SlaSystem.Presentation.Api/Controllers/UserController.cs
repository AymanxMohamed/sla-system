
using SlaSystem.Presentation.Api.Utils;

namespace SlaSystem.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ApiController
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, ISender sender) : base(sender)
    {
        _logger = logger;
    }
    
    [HttpGet("GetUsers/{role}", Name = "GetUsers")]
    [ProducesResponseType(typeof(Result<List<User>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<List<User>>>> GetUsers(Role role, CancellationToken cancellationToken)
    {
        var query = new GetUsersByRoleQuery(role); 
        
        var result = await Sender.Send(query, cancellationToken);
           
        if (result.IsFailure)
            return BadRequest(result.Error); 
        
        var userDtos = result.Value.Select(AutoMapper.MapUser);
        
        return Ok( Result.Success(userDtos));
    }
    
    [HttpPost("CreateUser", Name = "CreateUser")]
    [ProducesResponseType(typeof(Result<User>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<User>>> CreateUser([FromBody] CreateUserRequest createUserRequest, 
        CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(UserName.Create(createUserRequest.UserName), 
            Password.Create(createUserRequest.Password), 
            Zone.Create(createUserRequest.Zone), 
            Guid.Parse(createUserRequest.QueueId), 
            Role.User);
        var result = await Sender.Send(command, cancellationToken);
        
        if (result.IsFailure)
            return BadRequest(result.Error); 
        
        var userDto = AutoMapper.MapUser(result.Value);
        return Created("/admin/users", Result.Success(userDto));
    }
    
    [HttpPost("CreateAdmin", Name = "CreateAdmin")]
    [ProducesResponseType(typeof(Result<User>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<User>>> Register([FromBody] CreateAdminRequest createAdminRequest, 
        CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(UserName.Create(createAdminRequest.UserName), 
            Password.Create(createAdminRequest.Password), Zone.Create(createAdminRequest.Zone), null, 
            Role.Admin);
        
        var result = await Sender.Send(command, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error); 
        var userDto = AutoMapper.MapUser(result.Value);
        return Created("/admin/admins", Result.Success(userDto));
    }
}
