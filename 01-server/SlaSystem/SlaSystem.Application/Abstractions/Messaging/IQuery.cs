using MediatR;
using SlaSystem.Domain.Shared;

namespace SlaSystem.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
