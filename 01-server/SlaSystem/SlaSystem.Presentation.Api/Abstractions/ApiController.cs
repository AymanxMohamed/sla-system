using MediatR;

namespace SlaSystem.Presentation.Api.Abstractions;

public class ApiController : ControllerBase
{
    protected readonly ISender Sender;
    public ApiController(ISender sender) => Sender = sender;
}