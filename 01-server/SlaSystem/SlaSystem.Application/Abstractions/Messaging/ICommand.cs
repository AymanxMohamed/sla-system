﻿using MediatR;
using SlaSystem.Domain.Shared;

namespace SlaSystem.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
    
}