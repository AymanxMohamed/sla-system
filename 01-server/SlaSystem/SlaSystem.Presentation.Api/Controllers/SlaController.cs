using Microsoft.AspNetCore.Mvc;
using SlaSystem.Application.Slas.Commands;
using SlaSystem.Application.Slas.Queries;
using SlaSystem.Presentation.Api.Contracts.Slas;
using SlaSystem.Presentation.Api.Utils;

namespace SlaSystem.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlaController : ApiController
{
    private readonly ILogger<UserController> _logger;

    public SlaController(ILogger<UserController> logger, ISender sender) : base(sender)
    {
        _logger = logger;
    }
    
    [HttpGet("GetSlas", Name = "GetSlas")]
    [ProducesResponseType(typeof(Result<List<Sla>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<List<Sla>>>> GetSlas(CancellationToken cancellationToken)
    {
        var query = new GetSlasQuery(); 
        
        var result = await Sender.Send(query, cancellationToken);
   
        if (result.IsFailure)
            return BadRequest(result.Error); 
        
        var slaDtos = result.Value.Select(AutoMapper.MapSla);
        
        return Ok(Result.Success(slaDtos));
    }
    
    [HttpPost("CreateSla", Name = "CreateSla")]
    [ProducesResponseType(typeof(Result<Sla>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<Sla>>> CreateSla([FromBody] CreateSlaRequest createSlaRequest, 
        CancellationToken cancellationToken)
    {
        var command = new CreateSlaCommand(createSlaRequest.RequestType, 
            createSlaRequest.Severity, createSlaRequest.DurationInHours);
        
        var result = await Sender.Send(command, cancellationToken);
           
        if (result.IsFailure)
            return BadRequest(result.Error); 
        
        var slaDto = AutoMapper.MapSla(result.Value);

        return Created("/admin/slas", Result.Success(slaDto));

    }
}
