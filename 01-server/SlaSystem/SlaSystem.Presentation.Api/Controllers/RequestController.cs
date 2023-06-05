using Microsoft.AspNetCore.Mvc;
using SlaSystem.Application.Requests.Commands;
using SlaSystem.Application.Requests.Queries;
using SlaSystem.Application.Slas.Commands;
using SlaSystem.Presentation.Api.Contracts.Requests;

namespace SlaSystem.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestController : ApiController
{
    private readonly ILogger<UserController> _logger;

    public RequestController(ILogger<UserController> logger, ISender sender) : base(sender)
    {
        _logger = logger;
    }
    
        
    [HttpGet("GetClientRequests/{clientId}", Name = "GetClientRequests")]
    [ProducesResponseType(typeof(Result<List<Request>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<List<Request>>>> GetClientRequests(string clientId, CancellationToken cancellationToken)
    {
        var query = new GetClientRequestsQuery(Guid.Parse(clientId)); 
        
        var result = await Sender.Send(query, cancellationToken);
        
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
    
    [HttpGet("GetUserRequests/{userId}", Name = "GetUserRequests")]
    [ProducesResponseType(typeof(Result<List<Request>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<List<Request>>>> GetUserRequests(string userId, CancellationToken cancellationToken)
    {
        var query = new GetClientRequestsQuery(Guid.Parse(userId)); 
        
        var result = await Sender.Send(query, cancellationToken);
        
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
    
    [HttpGet("GetRequest/{id}", Name = "GetRequest")]
    [ProducesResponseType(typeof(Result<Request>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<Request>>> GetRequest(string id, CancellationToken cancellationToken)
    {
        var query = new GetRequestByIdQuery(Guid.Parse(id)); 
        
        var result = await Sender.Send(query, cancellationToken);
        
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
    
    [HttpPost("CreateRequest", Name = "CreateRequest")]
    [ProducesResponseType(typeof(Result<Request>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<Request>>> CreateSla([FromBody] CreateRequestPayload createRequestPayload, 
        CancellationToken cancellationToken)
    {
        var command = new CreateRequestCommand(createRequestPayload.RequestType,
            Description.Create(createRequestPayload.Description), Guid.Parse(createRequestPayload.ClientId));
        
        var result = await Sender.Send(command, cancellationToken);
        
        return result.IsSuccess ? Created("/client/requests", result) : BadRequest(result.Error);
    }
}
