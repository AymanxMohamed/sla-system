using SlaSystem.Application.Queues.Commands;
using SlaSystem.Application.Queues.Queries;
using SlaSystem.Presentation.Api.Contracts.Queues;
using SlaSystem.Presentation.Api.Utils;

namespace SlaSystem.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QueueController : ApiController
{
    private readonly ILogger<UserController> _logger;

    public QueueController(ILogger<UserController> logger, ISender sender) : base(sender)
    {
        _logger = logger;
    }
    
    [HttpGet("GetQueues", Name = "GetQueues")]
    [ProducesResponseType(typeof(Result<List<Queue>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<List<Queue>>>> GetQueues(CancellationToken cancellationToken)
    {
        var query = new GetQueuesQuery(); 
        
        var result = await Sender.Send(query, cancellationToken);
        
        if (result.IsFailure)
            return BadRequest(result.Error); 
        
        var queueDtos = result.Value.Select(AutoMapper.MapQueue).ToList();
        
        return Ok(Result.Success(queueDtos)) ;
    }
    
    [HttpPost("CreateQueue", Name = "CreateQueue")]
    [ProducesResponseType(typeof(Result<Queue>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<QueueDto>>> CreateQueue([FromBody] CreateQueueRequest createQueueRequest, 
        CancellationToken cancellationToken)
    {
        var command = new CreateQueueCommand(createQueueRequest.RequestType, 
            QueueName.Create(createQueueRequest.QueueName));
        
        var result = await Sender.Send(command, cancellationToken);
        
        if (result.IsFailure)
            return BadRequest(result.Error); 

        var queueDto = AutoMapper.MapQueue(result.Value);

        return Created("/admin/queues", Result.Success(queueDto));
    }
}
