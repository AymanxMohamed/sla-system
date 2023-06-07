using Microsoft.AspNetCore.Mvc;
using SlaSystem.Application.Requests.Commands;
using SlaSystem.Application.Requests.Queries;
using SlaSystem.Application.Slas.Commands;
using SlaSystem.Domain.Errors;
using SlaSystem.Presentation.Api.Contracts.Requests;
using SlaSystem.Presentation.Api.Utils;

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
        
        var isParsed = Guid.TryParse(clientId, out var guid);
        
        if (!isParsed)
        {
            var failure = Result.Failure<Request>(new Error("Request.InvalidId",
                "Invalid Client Id"));
            return BadRequest(failure.Error);
        }
        
        var query = new GetClientRequestsQuery(guid); 
        
        var result = await Sender.Send(query, cancellationToken);
        
        if (result.IsFailure)
            return BadRequest(result.Error);
        
        var requestDtos = result.Value.Select(AutoMapper.MapRequest);
        
        return Ok(Result.Success(requestDtos));
    }
    
    [HttpGet("GetUserRequests/{userId}", Name = "GetUserRequests")]
    [ProducesResponseType(typeof(Result<List<Request>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<List<Request>>>> GetUserRequests(string userId, CancellationToken cancellationToken)
    {
        var isParsed = Guid.TryParse(userId, out var guid);
        
        if (!isParsed)
        {
            var failure = Result.Failure<Request>(new Error("Request.InvalidId",
                "Invalid Owner Id"));
            return BadRequest(failure.Error);
        }
        
        var query = new GetUserRequestsQuery(guid); 
        
        var result = await Sender.Send(query, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);
        
        var requestDtos = result.Value.Select(AutoMapper.MapRequest);

        return Ok(Result.Success(requestDtos));
    }
    
    [HttpGet("GetRequestsByRequestType/{requestType}", Name = "GetRequestsByRequestType")]
    [ProducesResponseType(typeof(Result<List<Request>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<List<Request>>>> GetRequestsByRequestType(RequestType requestType, 
        CancellationToken cancellationToken)
    {
        var query = new GetRequestsByRequestTypeQuery(requestType); 
        
        var result = await Sender.Send(query, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);
        
        var requestDtos = result.Value.Select(AutoMapper.MapRequest);

        return Ok(Result.Success(requestDtos));
    }
    
    [HttpGet("GetRequest/{id}", Name = "GetRequest")]
    [ProducesResponseType(typeof(Result<Request>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<Request>>> GetRequest(string id, CancellationToken cancellationToken)
    {
        var isParsed = Guid.TryParse(id, out var guid);
        
        if (!isParsed)
        {
            var failure = Result.Failure<Request>(new Error("Request.InvalidId",
                "Invalid Request Id"));
            return BadRequest(failure.Error);
        }
        var query = new GetRequestByIdQuery(guid); 
        
        var result = await Sender.Send(query, cancellationToken);

        if (result.Value is null)
           {   
                result = Result.Failure<Request>(DomainErrors.Request.InvalidRequestId);
                return BadRequest(result.Error);
           }
        
        if (result.IsFailure)
            return BadRequest(result.Error);
        
        var requestDto = AutoMapper.MapRequest(result.Value);

        return Ok(Result.Success(requestDto));
    }
    
    [HttpPost("CreateRequest", Name = "CreateRequest")]
    [ProducesResponseType(typeof(Result<Request>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<Request>>> CreateRequest([FromBody] CreateRequestPayload createRequestPayload, 
        CancellationToken cancellationToken)
    {
        
        var isParsed = Guid.TryParse(createRequestPayload.ClientId, out var guid);

        if (!isParsed)
        {
            var failure = Result.Failure<Request>(new Error("Request.InvalidId",
                "Invalid Client Id"));
            return BadRequest(failure.Error);
        }
        
        var command = new CreateRequestCommand(createRequestPayload.RequestType,
            Description.Create(createRequestPayload.Description), guid);
        
        var result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);
        
        var requestDto = AutoMapper.MapRequest(result.Value);

        return Created("/client/requests", Result.Success(requestDto));
    }
    
        
    [HttpPatch("AssignRequest", Name = "AssignRequest")]
    [ProducesResponseType(typeof(Result<Result>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result>> AssignRequest([FromBody] AssignRequestPayload assignRequestPayload, 
        CancellationToken cancellationToken)
    {
        var isOwnerParsed = Guid.TryParse(assignRequestPayload.OwnerId, out var ownerGuid);

        if (!isOwnerParsed)
        {
            var failure = Result.Failure<Request>(new Error("Request.InvalidId",
                "Invalid Owner Id"));
            return BadRequest(failure.Error);
        }
        
        var isRequestParsed = Guid.TryParse(assignRequestPayload.RequestId, out var requestGuid);
        
        if (!isRequestParsed)
        {
            var failure = Result.Failure<Request>(new Error("Request.InvalidId",
                "Invalid Request Id"));
            return BadRequest(failure.Error);
        }
        
        var command = new AssignUserToRequestCommand(ownerGuid, 
            requestGuid);
        
        var result = await Sender.Send(command, cancellationToken);
        
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
    
    [HttpPatch("CloseRequest/{requestId}", Name = "CloseRequest")]
    [ProducesResponseType(typeof(Result<Result>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result>> CloseRequest(string requestId, CancellationToken cancellationToken)
    {
        var isParsed = Guid.TryParse(requestId, out var guid);
        
        if (!isParsed)
        {
            var failure =Result.Failure<Request>(new Error("Request.InvalidId", 
                "Invalid Request Id"));
            return BadRequest(failure.Error);
        }
        
        var command = new CloseRequestCommand(guid);
        
        var result = await Sender.Send(command, cancellationToken);
        
        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
    
}
